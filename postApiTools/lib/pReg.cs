using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class pReg
    {
        public static string createData = "postApiTools";

        public static string createDataExe = createData + ".exe";

        /// <summary>
        /// 注册协议
        /// </summary>
        public static void install()
        {
            try
            {
                var surekamKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(createData);
                //以下这些参数都是固定的，不需要更改，直接复制过去 
                var shellKey = surekamKey.CreateSubKey("shell");
                var openKey = shellKey.CreateSubKey("open");
                var commandKey = openKey.CreateSubKey("command");
                surekamKey.SetValue("URL Protocol", "");
                //这里可执行文件取当前程序全路径，可根据需要修改
                var exePath = Config.exePath + "/postApiToolsMessage.exe";
                commandKey.SetValue("", "\"" + exePath + "\"" + " \"%1\"");
            }
            catch
            {

            }
        }

        /// <summary>
        /// 删除协议
        /// </summary>
        public static void uninstall()
        {
            try
            {
                // 直接删除节点
                Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(createData);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 创建注册表项
        /// </summary>
        /// <param name="price"></param>
        public static void create(string price)
        {
            //使用CreateSubKey()在SOFTWARE下创建子项test
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSoftWare = hklm.CreateSubKey(@"SOFTWARE\" + price);
            hklm.Close();
            hkSoftWare.Close();
        }

        /// <summary>
        /// 读取注册表项
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static RegistryKey getReg(string price)
        {
            //使用OpenSubKey()打开项，获得RegistryKey对象，当路径不存在时，为Null。第二个参数为true，表示可写，可读，可删；省略时只能读。
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSoftWare = hklm.OpenSubKey(@"SOFTWARE\" + price, true);
            hklm.Close();
            hkSoftWare.Close();
            return hkSoftWare;

        }

        /// <summary>
        /// 删除注册表项
        /// </summary>
        /// <param name="price"></param>
        public static void deleteReg(string price)
        {
            //主要用到了DeleteSubKey(),删除test项
            RegistryKey hklm = Registry.LocalMachine;
            hklm.DeleteSubKey(@"SOFTWARE\" + price, true);  //为true时，删除的注册表不存在时抛出异常；当为false时不抛出异常。
            hklm.Close();
        }
        /// <summary>
        /// 创建注册表值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void createPrice(string price, string name, string value)
        {
            if (IsRegistryKeyExist(price))
            {
                if (IsRegistryValueNameExist(price, name))
                {

                    deleteRegPrice(price, name);
                }
            }
            else
            {
                create(price);
            }
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSoftWare = hklm.OpenSubKey(@"SOFTWARE\" + price, true);
            hkSoftWare.SetValue(name, value, RegistryValueKind.String);
            hklm.Close();
            hkSoftWare.Close();
        }

        /// <summary>
        /// 读取注册表值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string getRegPrice(string price, string name)
        {
            if (!IsRegistryKeyExist(price))
            {
                return "";
            }
            //主要用到了GetValue(),获得名称为"Name"的键值
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSoftWare = hklm.OpenSubKey(@"SOFTWARE\" + price, true);
            string sValue = hkSoftWare.GetValue(name).ToString();
            hklm.Close();
            hkSoftWare.Close();
            return sValue;
        }

        /// <summary>
        /// 删除注册表值
        /// </summary>
        /// <param name="name"></param>
        public static void deleteRegPrice(string price, string name)
        {
            if (!IsRegistryKeyExist(price))
            {
                return;
            }
            //主要用到了DeleteValue(),表示删除名称为"Name"的键值，第二个参数表示是否抛出异常
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSoftWare = hklm.OpenSubKey(@"SOFTWARE\" + price, true);
            hkSoftWare.DeleteValue(name, true);
            hklm.Close();
            hkSoftWare.Close();
        }

        /// <summary>
        /// 判断注册表项是否存在
        /// </summary>
        /// <param name="sKeyName"></param>
        /// <returns></returns>
        public static bool IsRegistryKeyExist(string sKeyName)
        {
            string[] sKeyNameColl;
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSoftWare = hklm.OpenSubKey(@"SOFTWARE");
            sKeyNameColl = hkSoftWare.GetSubKeyNames(); //获取SOFTWARE下所有的子项
            foreach (string sName in sKeyNameColl)
            {
                if (sName == sKeyName)
                {
                    hklm.Close();
                    hkSoftWare.Close();
                    return true;
                }
            }
            hklm.Close();
            hkSoftWare.Close();
            return false;
        }

        /// <summary>
        /// 判断键值是否存在
        /// </summary>
        /// <param name="sValueName"></param>
        /// <returns></returns>
        public static bool IsRegistryValueNameExist(string price, string sValueName)
        {
            string[] sValueNameColl;
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkTest = hklm.OpenSubKey(@"SOFTWARE\" + price);
            sValueNameColl = hkTest.GetValueNames(); //获取test下所有键值的名称
            foreach (string sName in sValueNameColl)
            {
                if (sName == sValueName)
                {
                    hklm.Close();
                    hkTest.Close();
                    return true;
                }
            }
            hklm.Close();
            hkTest.Close();
            return false;
        }


    }
}

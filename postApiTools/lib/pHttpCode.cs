using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class pHttpCode
    {
        // 摘要: 
        //     包含为 HTTP 定义的状态代码的值。
        /// <summary>
        /// https://www.cnblogs.com/landeanfen/p/5363846.html
        /// </summary>
        public enum HttpStatusCode
        {
            // 摘要: 
            //     等效于 HTTP 状态 100。 System.Net.HttpStatusCode.Continue 指示客户端可能继续其请求。
            Continue = 100,
            //
            // 摘要: 
            //     等效于 HTTP 状态 101。 System.Net.HttpStatusCode.SwitchingProtocols 指示正在更改协议版本或协议。
            SwitchingProtocols = 101,
            //
            // 摘要: 
            //     等效于 HTTP 状态 200。 System.Net.HttpStatusCode.OK 指示请求成功，且请求的信息包含在响应中。 这是最常接收的状态代码。
            OK = 200,
            //
            // 摘要: 
            //     等效于 HTTP 状态 201。 System.Net.HttpStatusCode.Created 指示请求导致在响应被发送前创建新资源。
            Created = 201,
            //
            // 摘要: 
            //     等效于 HTTP 状态 202。 System.Net.HttpStatusCode.Accepted 指示请求已被接受做进一步处理。
            Accepted = 202,
            //
            // 摘要: 
            //     等效于 HTTP 状态 203。 System.Net.HttpStatusCode.NonAuthoritativeInformation 指示返回的元信息来自缓存副本而不是原始服务器，因此可能不正确。
            NonAuthoritativeInformation = 203,
            //
            // 摘要: 
            //     等效于 HTTP 状态 204。 System.Net.HttpStatusCode.NoContent 指示已成功处理请求并且响应已被设定为无内容。
            NoContent = 204,
            //
            // 摘要: 
            //     等效于 HTTP 状态 205。 System.Net.HttpStatusCode.ResetContent 指示客户端应重置（或重新加载）当前资源。
            ResetContent = 205,
            //
            // 摘要: 
            //     等效于 HTTP 状态 206。 System.Net.HttpStatusCode.PartialContent 指示响应是包括字节范围的 GET
            //     请求所请求的部分响应。
            PartialContent = 206,
            //
            // 摘要: 
            //     等效于 HTTP 状态 300。 System.Net.HttpStatusCode.MultipleChoices 指示请求的信息有多种表示形式。
            //     默认操作是将此状态视为重定向，并遵循与此响应关联的 Location 标头的内容。
            MultipleChoices = 300,
            //
            // 摘要: 
            //     等效于 HTTP 状态 300。 System.Net.HttpStatusCode.Ambiguous 指示请求的信息有多种表示形式。 默认操作是将此状态视为重定向，并遵循与此响应关联的
            //     Location 标头的内容。
            Ambiguous = 300,
            //
            // 摘要: 
            //     等效于 HTTP 状态 301。 System.Net.HttpStatusCode.MovedPermanently 指示请求的信息已移到 Location
            //     头中指定的 URI 处。 接收到此状态时的默认操作为遵循与响应关联的 Location 头。
            MovedPermanently = 301,
            //
            // 摘要: 
            //     等效于 HTTP 状态 301。 System.Net.HttpStatusCode.Moved 指示请求的信息已移到 Location 头中指定的
            //     URI 处。 接收到此状态时的默认操作为遵循与响应关联的 Location 头。 原始请求方法为 POST 时，重定向的请求将使用 GET 方法。
            Moved = 301,
            //
            // 摘要: 
            //     等效于 HTTP 状态 302。 System.Net.HttpStatusCode.Found 指示请求的信息位于 Location 头中指定的
            //     URI 处。 接收到此状态时的默认操作为遵循与响应关联的 Location 头。 原始请求方法为 POST 时，重定向的请求将使用 GET 方法。
            Found = 302,
            //
            // 摘要: 
            //     等效于 HTTP 状态 302。 System.Net.HttpStatusCode.Redirect 指示请求的信息位于 Location 头中指定的
            //     URI 处。 接收到此状态时的默认操作为遵循与响应关联的 Location 头。 原始请求方法为 POST 时，重定向的请求将使用 GET 方法。
            Redirect = 302,
            //
            // 摘要: 
            //     等效于 HTTP 状态 303。 作为 POST 的结果，System.Net.HttpStatusCode.SeeOther 将客户端自动重定向到
            //     Location 头中指定的 URI。 用 GET 生成对 Location 标头所指定的资源的请求。
            SeeOther = 303,
            //
            // 摘要: 
            //     等效于 HTTP 状态 303。 作为 POST 的结果，System.Net.HttpStatusCode.RedirectMethod 将客户端自动重定向到
            //     Location 头中指定的 URI。 用 GET 生成对 Location 标头所指定的资源的请求。
            RedirectMethod = 303,
            //
            // 摘要: 
            //     等效于 HTTP 状态 304。 System.Net.HttpStatusCode.NotModified 指示客户端的缓存副本是最新的。 未传输此资源的内容。
            NotModified = 304,
            //
            // 摘要: 
            //     等效于 HTTP 状态 305。 System.Net.HttpStatusCode.UseProxy 指示请求应使用位于 Location 头中指定的
            //     URI 的代理服务器。
            UseProxy = 305,
            //
            // 摘要: 
            //     等效于 HTTP 状态 306。 System.Net.HttpStatusCode.Unused 是未完全指定的 HTTP/1.1 规范的建议扩展。
            Unused = 306,
            //
            // 摘要: 
            //     等效于 HTTP 状态 307。 System.Net.HttpStatusCode.RedirectKeepVerb 指示请求信息位于 Location
            //     头中指定的 URI 处。 接收到此状态时的默认操作为遵循与响应关联的 Location 头。 原始请求方法为 POST 时，重定向的请求还将使用
            //     POST 方法。
            RedirectKeepVerb = 307,
            //
            // 摘要: 
            //     等效于 HTTP 状态 307。 System.Net.HttpStatusCode.TemporaryRedirect 指示请求信息位于 Location
            //     头中指定的 URI 处。 接收到此状态时的默认操作为遵循与响应关联的 Location 头。 原始请求方法为 POST 时，重定向的请求还将使用
            //     POST 方法。
            TemporaryRedirect = 307,
            //
            // 摘要: 
            //     等效于 HTTP 状态 400。 System.Net.HttpStatusCode.BadRequest 指示服务器未能识别请求。 如果没有其他适用的错误，或者不知道准确的错误或错误没有自己的错误代码，则发送
            //     System.Net.HttpStatusCode.BadRequest。
            BadRequest = 400,
            //
            // 摘要: 
            //     等效于 HTTP 状态 401。 System.Net.HttpStatusCode.Unauthorized 指示请求的资源要求身份验证。 WWW-Authenticate
            //     头包含如何执行身份验证的详细信息。
            Unauthorized = 401,
            //
            // 摘要: 
            //     等效于 HTTP 状态 402。 保留 System.Net.HttpStatusCode.PaymentRequired 以供将来使用。
            PaymentRequired = 402,
            //
            // 摘要: 
            //     等效于 HTTP 状态 403。 System.Net.HttpStatusCode.Forbidden 指示服务器拒绝满足请求。
            Forbidden = 403,
            //
            // 摘要: 
            //     等效于 HTTP 状态 404。 System.Net.HttpStatusCode.NotFound 指示请求的资源不在服务器上。
            NotFound = 404,
            //
            // 摘要: 
            //     等效于 HTTP 状态 405。 System.Net.HttpStatusCode.MethodNotAllowed 指示请求的资源上不允许请求方法（POST
            //     或 GET）。
            MethodNotAllowed = 405,
            //
            // 摘要: 
            //     等效于 HTTP 状态 406。 System.Net.HttpStatusCode.NotAcceptable 指示客户端已用 Accept 头指示将不接受资源的任何可用表示形式。
            NotAcceptable = 406,
            //
            // 摘要: 
            //     等效于 HTTP 状态 407。 System.Net.HttpStatusCode.ProxyAuthenticationRequired 指示请求的代理要求身份验证。
            //     Proxy-authenticate 头包含如何执行身份验证的详细信息。
            ProxyAuthenticationRequired = 407,
            //
            // 摘要: 
            //     等效于 HTTP 状态 408。 System.Net.HttpStatusCode.RequestTimeout 指示客户端没有在服务器期望请求的时间内发送请求。
            RequestTimeout = 408,
            //
            // 摘要: 
            //     等效于 HTTP 状态 409。 System.Net.HttpStatusCode.Conflict 指示由于服务器上的冲突而未能执行请求。
            Conflict = 409,
            //
            // 摘要: 
            //     等效于 HTTP 状态 410。 System.Net.HttpStatusCode.Gone 指示请求的资源不再可用。
            Gone = 410,
            //
            // 摘要: 
            //     等效于 HTTP 状态 411。 System.Net.HttpStatusCode.LengthRequired 指示缺少必需的 Content-length
            //     头。
            LengthRequired = 411,
            //
            // 摘要: 
            //     等效于 HTTP 状态 412。 System.Net.HttpStatusCode.PreconditionFailed 指示为此请求设置的条件失败，且无法执行此请求。
            //     条件是用条件请求标头（如 If-Match、If-None-Match 或 If-Unmodified-Since）设置的。
            PreconditionFailed = 412,
            //
            // 摘要: 
            //     等效于 HTTP 状态 413。 System.Net.HttpStatusCode.RequestEntityTooLarge 指示请求太大，服务器无法处理。
            RequestEntityTooLarge = 413,
            //
            // 摘要: 
            //     等效于 HTTP 状态 414。 System.Net.HttpStatusCode.RequestUriTooLong 指示 URI 太长。
            RequestUriTooLong = 414,
            //
            // 摘要: 
            //     等效于 HTTP 状态 415。 System.Net.HttpStatusCode.UnsupportedMediaType 指示请求是不支持的类型。
            UnsupportedMediaType = 415,
            //
            // 摘要: 
            //     等效于 HTTP 状态 416。 System.Net.HttpStatusCode.RequestedRangeNotSatisfiable 指示无法返回从资源请求的数据范围，因为范围的开头在资源的开头之前，或因为范围的结尾在资源的结尾之后。
            RequestedRangeNotSatisfiable = 416,
            //
            // 摘要: 
            //     等效于 HTTP 状态 417。 System.Net.HttpStatusCode.ExpectationFailed 指示服务器未能符合 Expect
            //     头中给定的预期值。
            ExpectationFailed = 417,
            //
            UpgradeRequired = 426,
            //
            // 摘要: 
            //     等效于 HTTP 状态 500。 System.Net.HttpStatusCode.InternalServerError 指示服务器上发生了一般错误。
            InternalServerError = 500,
            //
            // 摘要: 
            //     等效于 HTTP 状态 501。 System.Net.HttpStatusCode.NotImplemented 指示服务器不支持请求的函数。
            NotImplemented = 501,
            //
            // 摘要: 
            //     等效于 HTTP 状态 502。 System.Net.HttpStatusCode.BadGateway 指示中间代理服务器从另一代理或原始服务器接收到错误响应。
            BadGateway = 502,
            //
            // 摘要: 
            //     等效于 HTTP 状态 503。 System.Net.HttpStatusCode.ServiceUnavailable 指示服务器暂时不可用，通常是由于过多加载或维护。
            ServiceUnavailable = 503,
            //
            // 摘要: 
            //     等效于 HTTP 状态 504。 System.Net.HttpStatusCode.GatewayTimeout 指示中间代理服务器在等待来自另一个代理或原始服务器的响应时已超时。
            GatewayTimeout = 504,
            //
            // 摘要: 
            //     等效于 HTTP 状态 505。 System.Net.HttpStatusCode.HttpVersionNotSupported 指示服务器不支持请求的
            //     HTTP 版本。
            HttpVersionNotSupported = 505,
        }

    }
}

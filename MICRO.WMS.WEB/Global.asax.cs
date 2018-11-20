using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

/// <summary>
/// 全局应用程序类
/// </summary>
namespace MICRO.WMS.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region 方法说明 

        // Application_Init：在应用程序被实例化或第一次被调用时，该事件被触发对于所有的HttpApplication 对象实例，它都会被调用
        // Application_Disposed：在应用程序被销毁之前触发这是清除以前所用资源的理想位置
        // Application_Error：当应用程序中遇到一个未处理的异常时，该事件被触发
        // Application_Start：在HttpApplication 类的第一个实例被创建时，该事件被触发它允许你创建可以由所有HttpApplication 实例访问的对象
        // Application_End：在HttpApplication 类的最后一个实例被销毁时，该事件被触发在一个应用程序的生命周期内它只被触发一次
        // Application_AuthenticateRequest：在安全模块建立起当前用户的有效的身份时，该事件被触发在这个时候，用户的凭据将会被验证
        // Application_AuthorizeRequest：当安全模块确认一个用户可以访问资源之后，该事件被触发
        // Session_Start：在一个新用户访问应用程序 Web 站点时，该事件被触发
        // Session_End：在一个用户的会话超时结束或他们离开应用程序 Web 站点时，该事件被触发
        // Application_BeginRequest：在接收到一个应用程序请求时触发对于一个请求来说，它是第一个被触发的事件，请求一般是用户输入的一个页面请求（URL）
        // Application_EndRequest：针对应用程序请求的最后一个事件
        // Application_PreRequestHandlerExecute：在 ASP.NET 页面框架开始执行诸如页面或 Web 服务之类的事件处理程序之前，该事件被触发
        // Application_PostRequestHandlerExecute：在 ASP.NET 页面框架结束执行一个事件处理程序时，该事件被触发
        // Applcation_PreSendRequestHeaders：在 ASP.NET 页面框架发送 HTTP 头给请求客户（浏览器）时，该事件被触发·Application_PreSendContent：在 ASP.NET 页面框架发送内容给请求客户（浏览器）时，该事件被触发
        // Application_AcquireRequestState：在 ASP.NET 页面框架得到与当前请求相关的当前状态（Session 状态）时，该事件被触发
        // Application_ReleaseRequestState：在 ASP.NET 页面框架执行完所有的事件处理程序时，该事件被触发这将导致所有的状态模块保存它们当前的状态数据
        // Application_ResolveRequestCache：在 ASP.NET 页面框架完成一个授权请求时，该事件被触发它允许缓存模块从缓存中为请求提供服务，从而绕过事件处理程序的执行
        // Application_UpdateRequestCache：在 ASP.NET 页面框架完成事件处理程序的执行时，该事件被触发，从而使缓存模块存储响应数据，以供响应后续的请求时使用
        // 这个事件列表看起来好像多得吓人，但是在不同环境下这些事件可能会非常有用
        // 使用这些事件的一个关键问题是知道它们被触发的顺序Application_Init 和Application_Start 事件在应用程序第一次启动时被触发一次相似地，
        // Application_Disposed 和 Application_End 事件在应用程序终止时被触发一次此外，
        // 基于会话的事件（Session_Start 和 Session_End）只在用户进入和离开站点时被使用其余的事件则处理应用程序请求，这些事件被触发的顺序是：
        // Application_BeginRequest
        // Application_AuthenticateRequest
        // Application_AuthorizeRequest
        // Application_ResolveRequestCache
        // Application_AcquireRequestState
        // Application_PreRequestHandlerExecute         
        // Application_PreSendRequestHeaders
        // Application_PreSendRequestContent
        // <<执行代码>>
        // Application_PostRequestHandlerExecute
        // Application_ReleaseRequestState
        // Application_UpdateRequestCache
        // Application_EndRequest

        #endregion

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

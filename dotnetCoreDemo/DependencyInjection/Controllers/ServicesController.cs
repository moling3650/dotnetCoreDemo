using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        readonly IMyScopedService scoped3;

        public ServicesController (IMyScopedService scoped)
        {
            scoped3 = scoped; // 通过控制器类构造函数获取服务
        }

        [HttpGet("lifetimes")]
        public int GetService([FromServices]IMySingletonService singleton1, // 通过控制器参数获取服务
                              [FromServices]IMySingletonService singleton2,
                              [FromServices]IMyTransientService transient1,
                              [FromServices]IMyTransientService transient2,
                              [FromServices]IMyScopedService scoped1,
                              [FromServices]IMyScopedService scoped2)
        {
            Console.WriteLine($"singleton1:{singleton1.GetHashCode()}");
            Console.WriteLine($"singleton2:{singleton2.GetHashCode()}");

            Console.WriteLine($"transient1:{transient1.GetHashCode()}");
            Console.WriteLine($"transient2:{transient2.GetHashCode()}");

            Console.WriteLine($"scoped1:{scoped1.GetHashCode()}");
            Console.WriteLine($"scoped2:{scoped2.GetHashCode()}");
            Console.WriteLine($"scoped3:{scoped3.GetHashCode()}");

            Console.WriteLine($"========请求结束=======");
            return 1;
        }
    }
}
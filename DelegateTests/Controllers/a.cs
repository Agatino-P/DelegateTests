using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;

namespace DelegateTests.Controllers;
[ApiController]
[Route("/")]
public class WeatherForecastController : ControllerBase
{
    private static  MyCalcDel One = new((b) => b*1);
    private static MyCalcDel Two = (b) => 2*b;

    private static Dictionary<int,MyCalcDel> delegates = new Dictionary<int,MyCalcDel>()
    {
        {1,One },
        {2,Two }
    };



    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get(int a, int b)
    {
        return Ok(delegates[a](b));
    }
}


delegate int MyCalcDel(int b);
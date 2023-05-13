using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;

namespace DelegateTests.Controllers;
[ApiController]
[Route("/")]
public class WeatherForecastController : ControllerBase
{
    private static  MyCalcDel One = new(() => 1);
    private static MyCalcDel Two = () => 2;

    private static Dictionary<int,MyCalcDel> delegates = new Dictionary<int,MyCalcDel>()
    {
        {1,One },
        {2,Two }
    };



    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get(int a)
    {
        return Ok(delegates[a]());
    }
}


delegate int MyCalcDel();
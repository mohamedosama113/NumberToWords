using Microsoft.AspNetCore.Mvc;
using NumberToWords.Services;

namespace NumberToWordsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberToWordsController : ControllerBase
    {
        [HttpGet]
        public string ConvertToWords(decimal number)
        {
            var ConvertN2WService = new ConvertNumberToWords();
            string words = ConvertN2WService.Convert(number);
            return words;
        }
        
    }
}

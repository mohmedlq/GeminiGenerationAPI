using DataAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ai_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiApiController : ControllerBase
    {
        private readonly IGeminiService _geminiService;

        public AiApiController(IGeminiService geminiService)
        {
            _geminiService = geminiService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate(
            [FromBody] Dtos.AiGenerateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Prompt))
            {
                return BadRequest(new
                {
                    error = "Prompt cannot be empty."
                });
            }

            try
            {
                var result = await _geminiService.GenerateAsync(
                    request.Prompt,
                    request.Schema,
                    request.Tokens
                );

                return Content(result, "application/json");
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    error = "An unexpected error occurred."
                });
            }
        }
    }
}
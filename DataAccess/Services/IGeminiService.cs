using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public interface IGeminiService
    {
       Task<string> GenerateAsync(string prompt, JsonElement schema,int? MaxTokens);

    }
}

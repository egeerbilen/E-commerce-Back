public class LowercaseResponseMiddleware
{
    private readonly RequestDelegate _next;

    public LowercaseResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        using (var responseBody = new MemoryStream())
        {
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var modifiedResponseBodyText = ConvertErrorsKeysToLowerCase(responseBodyText);

            await context.Response.WriteAsync(modifiedResponseBodyText);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }

    private string ConvertErrorsKeysToLowerCase(string json)
    {
        var jObject = Newtonsoft.Json.Linq.JObject.Parse(json);
        if (jObject.ContainsKey("errors"))
        {
            var errors = jObject["errors"] as Newtonsoft.Json.Linq.JObject;
            if (errors != null)
            {
                var result = new Newtonsoft.Json.Linq.JObject();

                foreach (var property in errors.Properties())
                {
                    result.Add(property.Name.ToLower(), property.Value);
                }

                jObject["errors"] = result;
            }
        }

        return jObject.ToString();
    }
}

namespace Number_interpreter
{
public static class Hundreds_Extensions
{ 
    public static IApplicationBuilder UseHundreds(this IApplicationBuilder builder)
    { 
        return builder.UseMiddleware<Hundreds_Middleware>();
    }
}}
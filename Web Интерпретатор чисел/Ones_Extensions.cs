namespace Number_interpreter
{ 
public static class Ones_Extensions
{ 
    public static IApplicationBuilder UseOnes(this IApplicationBuilder builder)
    { 
        return builder.UseMiddleware<Ones_Middleware>();
    }
}}
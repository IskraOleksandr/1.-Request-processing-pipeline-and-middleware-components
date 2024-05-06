namespace Number_interpreter
{

    public static class Thousands_Extensions
    { 
        public static IApplicationBuilder UseThousands(this IApplicationBuilder builder)
        { 
            return builder.UseMiddleware<Thousands_Middleware>();
        }
    }
}
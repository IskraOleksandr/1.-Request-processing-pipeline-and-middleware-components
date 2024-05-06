namespace Number_interpreter
{

    public static class Tens_Extensions
    { 
        public static IApplicationBuilder UseTens(this IApplicationBuilder builder)
        { 
            return builder.UseMiddleware<Tens_Middleware>();
        }
    }
}
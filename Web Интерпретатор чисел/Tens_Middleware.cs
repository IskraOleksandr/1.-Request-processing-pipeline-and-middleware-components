﻿namespace Number_interpreter
{

    public class Tens_Middleware
    { 
        private readonly RequestDelegate _next; 
        public Tens_Middleware(RequestDelegate next)
        { 
            _next = next;
        }
         
        public async Task Invoke(HttpContext context)
        { 
            string? token = context.Request.Query["number"];
            try
            { 
                var s = context.Session.GetString("number");  
                var number = Convert.ToInt32(token); 
                number = Math.Abs(number); 
                if (number < 10)
                {
                    await _next.Invoke(context);
                }
                else
                { 
                    number %= 100; 
                    if (number >= 20)
                    { 
                        number /= 10; 
                        string[] Numbers = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" }; 
                        context.Session.SetString("number",
                            context.Session.GetString("number") + " " + Numbers[number - 2]); 
                        await _next.Invoke(context);
                    } 
                    else if (number >= 11 && number <= 19)
                    { 
                        string[] Numbers =
                        {
                        "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen",
                        "nineteen"
                    }; 
                        await context.Response.WriteAsync("Your number is " + context.Session.GetString("number") +
                                                          Numbers[number - 11]);
                    } 
                    else if (number == 10)
                    { 
                        await context.Response.WriteAsync("Your number is " + context.Session.GetString("number") + " " +
                                                          "ten");
                    }
                    else
                    { 
                        await _next.Invoke(context);
                    }
                }
            } 
            catch (Exception)
            { 
                await context.Response.WriteAsync("Incorrect parameter");
            }
        }
    }
}
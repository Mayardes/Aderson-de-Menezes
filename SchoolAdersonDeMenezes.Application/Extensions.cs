using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;

namespace SchoolAdersonDeMenezes.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }

        public static string ToDashCase(this string text)
        {
            if(text == null)
                throw new ArgumentException(nameof(text));
            if(text.Length < 2)
                return text;
            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(text[0]));
            for(int i=1; i<text.Length; i++)
            {
                char c = text[i];
                if (char.IsUpper(c))
                {
                    sb.Append('-');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
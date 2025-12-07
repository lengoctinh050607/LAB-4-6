namespace bai1lab6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
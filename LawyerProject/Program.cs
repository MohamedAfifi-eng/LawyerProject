using LawyerProject.Data;
using LawyerProject.MyServices.UploadedFileService;
using LawyerProject.Services.AdministrativeWorkService;
using LawyerProject.Services.CaseClientsServices;
using LawyerProject.Services.CaseEnemiesServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<IcourtService, courtService>();
builder.Services.AddTransient<ICourtKindService, CourtKindService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IMaktabTawseekService, MaktabTawseekService>();
builder.Services.AddTransient<INyabaKindService, NyabaKindService>();
builder.Services.AddTransient<IAdministrativeWorkKindService, AdministrativeWorkKindService>();
builder.Services.AddTransient<ICaseKindService, CaseKindService>();
builder.Services.AddTransient<ICaseSubKindService, CaseSubKindService>();
builder.Services.AddTransient<INyabaService, NyabaService>();
builder.Services.AddTransient<IDayraService, DayraService>();
builder.Services.AddTransient<ITawkeelService, TawkeelService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IEnemyService, EnemyService>();
builder.Services.AddTransient<ICaseService, CaseService>();
builder.Services.AddTransient<IAdministrativeWorkServices, AdministrativeWorkServices>();
builder.Services.AddTransient<ITawkeelClientsService, TawkeelClientsService>();
builder.Services.AddTransient<ICaseClientsService, CaseClientsService>();
builder.Services.AddTransient<ICaseEnemiesService, CaseEnemiesService>();
builder.Services.AddTransient<IUploadedFileService, UploadedFileService>();

builder.Services.AddTransient(typeof(IGeneralService<>),typeof(GeneralService<>));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

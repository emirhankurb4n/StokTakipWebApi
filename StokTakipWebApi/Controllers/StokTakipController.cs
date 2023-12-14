using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StokTakipWebApi.Models;

namespace StokTakipWebApi.Controllers
{
    [Route("api/v1/[action]")]
    [ApiController]
    public class StokTakipController : ControllerBase
    {

        StokTakipDbContext ctx;
        public StokTakipController(StokTakipDbContext dbContext)
        {
            this.ctx = dbContext;
        }

        [HttpGet]
        public IEnumerable<TblKullanicilar> KullanicilariGetir()
        {
            return ctx.TblKullanicilars.ToList();
        }

        [HttpGet]
        public string Test() 
        {
            return "Merhaba Dünya";
        }
    }
}

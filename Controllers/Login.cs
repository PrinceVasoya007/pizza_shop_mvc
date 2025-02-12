namespace pizza_shop_MVC.Controllers;

public class Login : Controllers
{

     private readonly  ApplicationDbContent _db;

            public Login(ApplicationDbConect db){
                _db =db;
            }
        public IActionResult Index()
    {
          var objectList =_db.Role.ToList();
     
        return View();
    }


}

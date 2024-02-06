//using proyecto_tp1;
//using System.Collections.Generic;

//int opcion = 0;
//int idProducto = 0;

//List<Product> productos = new List<Product>();


//menu();

//while (opcion != 0) // white era para bucle 
//{
//    Console.Clear();
//    switch (opcion) // controol de acceso  / bucle 
//    {
//        case 1: //case me da el dato por donde ingresa dependiendo de la variable "opcion"
//            agregarProducto();
//            break; //rompe para seguir con la linea de abajo

//        case 5:
//            mostrarProductos();
//            break;

//        default:
//            Console.WriteLine("Opcion ingresa incorrecta");
//            break;
//    }

//    menu();
//}

//Console.WriteLine("Gracias por usar la aplicacion de axel");

//void menu() 
//{
//    Console.WriteLine("Ferreteria Axel");
//    Console.WriteLine("---------------- Menu -------------------------");
//    Console.WriteLine("1 - Agregar producto");
//    Console.WriteLine("5 - Mostrar Producto");
//    Console.WriteLine("3 - Salir");
//    opcion = Convert.ToInt32(Console.ReadLine());
//}

// void agregarProducto() //void no retorna en nada
//{

//    Console.WriteLine("Ingrese el nombre del producto");
//    string nombreProducto = Convert.ToString(Console.ReadLine());

//    Console.WriteLine("Ingrese el precio del producto");
//    double precio = Convert.ToDouble(Console.ReadLine());

//    Console.WriteLine("Ingrese el precio de venta del producto");
//    double salePrecio = Convert.ToDouble(Console.ReadLine());

//    Console.WriteLine("Ingrese el stock del producto");
//    int stock = Convert.ToInt32(Console.ReadLine());

//    Console.WriteLine("Ingrese el idUser del producto");
//    int idUser = Convert.ToInt32(Console.ReadLine());


//    Product producto = new Product(idProducto, nombreProducto, precio, salePrecio, stock, idUser);

//    idProducto += 1;
//    productos.Add(producto);

//}

//void mostrarProductos()
//{
//    foreach (Product product in productos) 
//    {
//        Console.WriteLine(product.Id);
//        Console.WriteLine(product.description);
//        Console.WriteLine(product.price);
//        Console.WriteLine(product.salePrice);
//        Console.WriteLine(product.stock);
//        Console.WriteLine(product.idUser);
//    }
//}


////SoldProduct celularvendido = new SoldProduct(2, 22, 3, 23);
////    //int id, int idproducto, int stock, int idsale

////Product tele = new Product();

////tele.Id = 1;
////tele.idUser = 1;
////tele.price = 98.99;
////tele.salePrice = 104.99;
////tele.description = "tv samsung";
////tele.stock = 30;

////Product cocina = new Product();

////cocina .Id = 2;
////cocina .idUser = 2;
////cocina.price = 35;
////cocina.salePrice = 40;
////cocina.stock=20;
////cocina.description = "cocina dream";


////Product computadora = new Product();

////computadora.Id = 3;
////computadora.idUser = 3;
////computadora.price = 200;
////computadora.salePrice = 230;
////computadora.stock = 20;
////computadora.description = "notebook hp lp3450";

//void crearUsusario ()
//{ 

//Console.WriteLine("Ingrese id ");
//string id = Convert.ToString(Console.ReadLine());

//Console.WriteLine("Ingrese nombre de usuario ");
//string username = Convert.ToString(Console.ReadLine());

//Console.WriteLine("Ingrese nombre");
//string name = Convert.ToString(Console.ReadLine());

//Console.WriteLine("Ingrese apellido");
//string lastname = Convert.ToString(Console.ReadLine());

//Console.WriteLine("Ingrese email ");
//string email = Convert.ToString(Console.ReadLine());

//Console.WriteLine("Ingrese contraseña");
//string password = Convert.ToString(Console.ReadLine());

//}

////Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail 

////private int Id { get; set; }

////private string Name { get; set; } = string.Empty;

////private string lastName { get; set; } = string.Empty;

////private string password { get; set; } = string.Empty;

////private string email { get; set; } = string.Empty;

////private string username { get; set; } = string.Empty;




using proyecto_tp1.data;
using proyecto_tp1.models;


//var listaUsuarios = UserData.getUsers();


//foreach (var user in listaUsuarios) 
//{
//    Console.WriteLine(user.id);
//    Console.WriteLine(user.Name);
//    Console.WriteLine(user.lastName);
//    Console.WriteLine(user.email);
//    Console.WriteLine(user.password);
//}

var user = UserData.ObtenerUsuario(2);

Console.WriteLine( user.Name );
Console.WriteLine(user.id);
Console.WriteLine(user.lastName);
Console.WriteLine(user.email);
Console.WriteLine(user.password);


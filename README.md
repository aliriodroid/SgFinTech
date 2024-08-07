# SgFinTech
Sg Financial Tech Challenge

La solucion actual consta de dos servicios,Users y BankAccount. El primero para registro y login de usuarios y el segundo para creacion y manejo de cuenta bancaria. 

Sobre el proyecto USERS, se implemento unca arquitecura veritcal con controladores que brinda dos endpoints, uno para crear el usuario y otro para el login. este ultimo nos retorna un token que despues nos permitira los accesos a los ednpoints del servicio de BankAccount.

Sobre el proyecto BankAccount se uso la misma arquitectura y provee de tres endpoints, creacion de cuenta, actualizacion de saldo e info de cuenta. 

1.- El proyecto contiene una imagen de sql server express, para levantarla solo debe ejecutar en la terminal de las carperas Users o BankAccount el siguiente comando:
      
      docker compose up
      
Ya el proyecto esta preconfigurado con el connection string del paso anterior, si desea usar su propia instancia solo debe cambiar el connection string del proyecto Users y BankAccount, en el archivo appsetting.json, respectivamente.

2.- Dentro del folder Users, ejecutar:

          dotnet ef database update
      
3.- Dentro del folder BankAccount, ejecutar:

     dotnet ef database update           
Los pasos 2 y 3 son para la ejecucion de las migraciones,se utilizo ef core como ORM.

4. Correr desde visual studio o cualquier ide el proyecto.


El proyecto contiene swagger, al levantar los dos proyectos de la solucion se abriran dos ventanas en su explorador correspondientes a cada servicio:

Servicio Uers:

Registar una cuenta

<img width="1451" alt="image" src="https://github.com/user-attachments/assets/7aaa5c44-02a9-4e99-b50e-bf45542cec17">

Login con la cuenta creada
<img width="1322" alt="image" src="https://github.com/user-attachments/assets/b58d4144-3ba8-48ac-8586-a37e67ca16be">

Copiar el token obtenido


Servicio BankAccount

En la solapa autorize ingresar el token precedido por la palabra Bearer.
<img width="1453" alt="image" src="https://github.com/user-attachments/assets/ac92a699-6430-4a4a-9734-38534af4f853">
Pegar el token obtenido en el servicio users:

<img width="1449" alt="image" src="https://github.com/user-attachments/assets/5667a313-688a-4d91-92b5-af8c1c041650">

Crear una cuenta bancaria

<img width="1328" alt="image" src="https://github.com/user-attachments/assets/0825ea5d-d6fd-445d-919c-8060251cdde2">


Response:

    {
    "id": 5,
    "userId": "184c1e59-bdf5-49b6-868f-c3701d215165",
    "currency": 1,
    "amount": 5000000,
    "cbu": 1775382773,
    "status": 1,
    "createdAt": "2024-08-06T16:16:10.184364",
    "updatedAt": null,
    "deletedAt": null
  }

Solicitar saldo

<img width="1365" alt="image" src="https://github.com/user-attachments/assets/9f17bee7-3f58-4917-9e69-751c7acd1a86">

Depositar o retirar un monto: Los tipos de operacion son 010 para retiro o 001 para deposito.

<img width="1344" alt="image" src="https://github.com/user-attachments/assets/e4d3fcae-e6fb-4c31-9639-c1af7f8f179a">






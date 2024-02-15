# Домашнее задание к Уроку 4. Безопасность и контейнеризация приложений
---
цель его работы - аутентифицировать пользователей нашей системы и создавать для них JWT-токен посредством которого они смогут аутентифицироваться в GraphQL API . Мы будем хранить пользователей в базе данных,

*Научитесь собирать докер образы с зависимостями удалив работу с базой из проекта GraphQL-сервера и подключив ее как зависимость отдельным проектом из первого практического занятия.
Подготовьте докер-образы для всех приложений(API-Gateway и сервисы библиотеки) из лекции посвященной микросервисам и запустите приложение путем составления compose-файла для запуска всех необходимых контейнеров.

---
## РЕШЕНИЕ:
---

Для внедрения аутентификации пользователей были выполнены следующие действия:

1. Добавляем зависимость, NuGet пакет Microsoft.AspNetCore.Authentication.JwtBearer.
2. Настраиваем файл appsettings.json:
```
  "JWT": {
    "Key": "sjdsahdksyhiadsjkagdjsaghja",
    "Issuer": "http://localhost:5247",
    "Audience": "http://localhost:5247"

```
3.  Настраиваем запуск приложения в файле Program.cs:

```
       builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                                                    .GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

```

```
            app.UseAuthentication();
            app.UseAuthorization();


```

4. Добавляем роли:
    4.1. Добавляем класс (нумератор) UseRole.cs;
    4.2. Добавляем класс LoginModel.cs в котором будут содержаться логин и пароль;
    4.3. Добавляем класс UserModel.cs в котором будет содержаться информация о пользователе;
5. Добавляем интерфейс IUserAuthenticationService.cs.
6. Добавляем класс AuthenticationService.cs который реализует интерфейс IUserAuthenticationService.cs
7. Добавляем класс LoginController.cs в котором будет реализована возможность пользователям аутентифицироваться. 
8. Добавляем зависимость в файле Program.cs:
```

builder.Services.AddScoped<IUserAuthenticationService, AuthenticationService>();

```



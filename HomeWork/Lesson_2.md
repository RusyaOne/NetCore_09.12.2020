Теория:
1. Повторите ветвление и слияние в гит: https://git-scm.com/book/ru/v2 (п. 3.2)
2. Другой взгляд на rebase и merge: https://habr.com/ru/post/432420/
3. Рассуждения по CI/CD: https://habr.com/ru/company/piter/blog/343270/
5. Про Application Layers: https://metanit.com/sharp/mvc5/23.5.php

Практика:
1. Добавьте в ваш репозиторий с ДЗ файл .gitignore для .NET Core чтоб убрать лишние файлы из под версионного контроля. Исключение должны составить файлы необходимые для AppVeyor.
2. Добавьте ваш репозиторий с ДЗ под Continuous Integration в AppVeyor.
3. Создайте проект по шаблону Empty Project. Добавьте папку Controllers и класс HomeController добавьте туда метод Index. Создайте соответствующее view.
4. Добавьте в методы Configure и ConfigureServices класса Startup вызов нужных методов для того чтоб работал вызов созданного вами метода из контроллера.
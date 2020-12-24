Теория:
1. Академическое описание паттерна Repository: http://design-pattern.ru/patterns/repository.html
2. Про внедрение зависимостей (DI) и зависимости в частности: https://habr.com/en/post/349836/, если будет интересно или необходимо можете прочитать весь цикл этих статьей, на который есть ссылка в статье.
3. Оригинальная статья про IoC и DI от Марка Фовлера: https://martinfowler.com/articles/injection.html#InversionOfControl
4. Метафорическое(простыми аналогиями) описание преимущества DI контейнеров в первых двух комментариях: https://ru.stackoverflow.com/questions/461814/%D0%97%D0%B0%D1%87%D0%B5%D0%BC-%D0%BD%D1%83%D0%B6%D0%B5%D0%BD-dependency-injection-%D0%BA%D0%BE%D0%BD%D1%82%D0%B5%D0%B9%D0%BD%D0%B5%D1%80
5. Про Lazy и Eager загрузки данных: https://professorweb.ru/my/entity-framework/6/level3/3_4.php
6. Основные концепции в EF: https://metanit.com/sharp/entityframeworkcore/, https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli

Практика:
1. В HumanController добавьте action Country(если он у вас уже есть с занятия, переделайте согласно этому заданию). Action Country должен принимать один параметр - name(это название страны).
Сделайте так чтоб в виде таблицы выводились все человеки из страны, имя которой было передано в action. 
2. В Action Index контроллера HumanController добавьте возможность выводить всех человеков, если параметр id равен нулю, в обратном случае выводить человека Id которого равен значению параметра id. 
3. Создайте интерфейс репозитория (паттерн Repository) для работы с моделью Human. Пусть этот интерфейс содержит пять методов GetAllHumans, GetHuman, CreateHuman, ModifyHuman, DeleteHuman. Создайте класс реализующий этот интерфейс. Реализуйте все методы из интерфейса. Досуп к сущности Humans вы сможете получить используя ваш класс контекста. 
4. Замените использование вашего класса контекста в HumanController использованием вашего нового репозитория из 3 задания.
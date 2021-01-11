Теория:
1. Доп. информация по Tag Helpers: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-5.0
2. Стандартные tag helpers: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-3.1#built-in-aspnet-core-tag-helpers 
(мы рассмотрели Anchor Tag Helpers и Form Tag Helpers)
3. Про ViewModel: https://metanit.com/sharp/aspnet5/8.2.php

Сейчас много кто создает новый проект для каждого ДЗ, однако вам легче будет создать один проект для ДЗ в котором выполнять все ДЗ, и вести некоторую классную работу т.к. мы будем базироваться на что уже сделали раньше. 

Практика:
1. Приведите в порядок контроллер Home: Избавьтесь от использования контекста напрямую, передавайте параметры через ViewModel.
2. Приведите в порядок контроллер Human: На данный момент там как минимум должны быть actions Index, Create(Get и Post), Delete. Данные должны передаваться во View c помощью ViewModel (Если существующая модель подходит для передачи данных, используем ее и не создаем ViewModel). 
3. Сделайте небольшой рефакторинг action Human/Index, чтоб у вас не было необходимости открывать несколько связей с БД одновременно и Select использовался всего раз.
4. Добавьте ссылку на колонку CountryName во view Human/Index, при нажатии на которую будет отображаться информация о соответствующей стране. Нужную страну находите по Id. Используйте Tag Helpers.
5. Добавьте функционал для добавления новой страны. При написании формы используйте Tag Helpers.
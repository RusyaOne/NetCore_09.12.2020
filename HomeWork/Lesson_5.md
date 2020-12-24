Теория:
1. Про параметры в Path и Query и когда их использовать: https://medium.com/@fullsour/when-should-you-use-path-variable-and-query-parameter-a346790e8a6d
2. Русским языком про REST: https://medium.com/@andr.ivas12/rest-%D0%BF%D1%80%D0%BE%D1%81%D1%82%D1%8B%D0%BC-%D1%8F%D0%B7%D1%8B%D0%BA%D0%BE%D0%BC-90a0bca0bc78. Полезная на данный момент информация: от начала статьи до раздела "Идемпотентность".
3. Про Mime типы: https://alekseev74.ru/lessons/show/http/mime-types

Практика:
1. Создайте репозиторий для модели Country (интерфейс и реализацию). Добавьте основные операции. По желанию можете создать подпапку для репозиториев.
2. Создайте модель District (область страны). Задайте этой модели базовые свойства (название и т.д.) и необходимые ссылочные свойства (подумайте какие типы связей у новой модели к уже существующим моделям).
3. Создайте с помощью Code First для модели District соответсвующую таблицу. Заполните ее несколькини значениями через миграции.
4. Добавьте в контроллер Human action с помощью которого по id человека можно вывести название области. Используйте маршрутизацию через атрибуты для этого action. Задайте какого типа должен быть параметр и пределы в которых должно находиться его значение. 

Если мы вешаем атрибут на action или котроллер они больше не находятся по паттерну в описаному UseStartup():
"Actions are either conventionally routed or attribute routed. Placing a route on the controller or the action makes it attribute routed. Actions that define attribute routes cannot be reached through the conventional routes and vice-versa. Any route attribute on the controller makes all actions in the controller attribute routed."
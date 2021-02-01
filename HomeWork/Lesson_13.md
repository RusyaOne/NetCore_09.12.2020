Теория:
1. Про OSI: https://www.cloudflare.com/learning/ddos/glossary/open-systems-interconnection-model-osi/
2. Про юнит-тестирование: https://habr.com/ru/post/169381/#:~:text=%D0%9C%D0%BE%D0%B4%D1%83%D0%BB%D1%8C%D0%BD%D0%BE%D0%B5%20%D1%82%D0%B5%D1%81%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5%2C%20%D0%B8%D0%BB%D0%B8%20%D1%8E%D0%BD%D0%B8%D1%82%2D%D1%82%D0%B5%D1%81%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5,%D0%BA%D0%B0%D0%B6%D0%B4%D0%BE%D0%B9%20%D0%BD%D0%B5%D1%82%D1%80%D0%B8%D0%B2%D0%B8%D0%B0%D0%BB%D1%8C%D0%BD%D0%BE%D0%B9%20%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8%20%D0%B8%D0%BB%D0%B8%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D0%B0.
3. Про TDD: http://agiledata.org/essays/tdd.html#:~:text=Test%2Ddriven%20development%20(TDD)%20is%20a%20development%20technique%20where,Agile%20DBAs%20for%20database%20development.
4. Пример TDD для Bowling game: https://www.youtube.com/watch?v=l4xhTq4qmC0&ab_channel=JeremyClark
(Лучше всего был бы пример от самого Uncle Bob, который этот пример придумал (Clean Code, выпуск 6 часть 2), но доступ к этим видео нужно покупать)

Практика:
1. Сделайте так, чтоб новый учасник чата добавлялся не в тот момент, когда открывается новая вкладка, а когда на этой вкладке вы указываете имя нового учасника и нажимаете кнопку 'Join chat' (Добавьте кнопку и текстовое поле для имени учасника).
Вместо Guid должно отображаться имя учасника.
2. Подчистить пример, сделать интерфейс для обработчика подключений, сделать так чтоб оба сценария(Stream, Chat) работали на разных Actions и была возможность попробовать каждый сценарий при запуске программы.
3. Потренируйтесь с тестами и добавьте свою реализацию примера BowlingGame, с тестами написаными на xUnit.
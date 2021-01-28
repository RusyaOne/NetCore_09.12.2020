Теория:
1. Про итерацию с AsyncEnumerable: https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8
2. Отличное интервью с разработчиком Channels: https://www.youtube.com/watch?v=gT06qvQLtJ0

Практика:
1. Зарегистрируйте IExampleRestClient как scoped, найдите способ использовать его в hosted сервисах при таком типе регистрации.
2. Сделайте методы FileProcessingChannel ассинхронными.
3. Сделайте созданные нами HostedSevices асинхронными, все методы, которые используются в них сделайте также ассинхронными.
4. Попробуйте доставать элементы из FileProcessing не подному, а все которые на данный момент есть в очереди. Воспользуйтесь await foreach.
# SimpleRunner

Про архитектурные решения.

В качестве основного паттерна выбран простая версия MVVM так как это позволяет отделить визуализацию объектов от логики объектов. Таким образом используется минимальное количество обращений к классам Unity.

В качестве модели для MVVM  я выбирал между ECS и Strategy паттерн. Оба эти паттерна позволяют дополнять функционал с минимальным редактированием имеющихся классов (принцип открытости-закрытости из SOLID). ECS может быть избыточно сложным паттерном для маленького проекта, хотя и обещает в дополнение к архитектурным преимуществам увеличение производительности.  Я выбрал Strategy паттерн (IPlayerMovementStrategy).

Используется  внедрение зависимостей (класса SceneStarter). Вместо ручного внедрения можно было использовать некий фреймворк, например Zenject.
Кроме того, использован паттерн Factory для сокрытия способа создания новых объектов. Одна из фабрик создает объекты с помощью паттерна Object pool (для монеток и объектов на фоне).

Также широко использованы интерфейсы для сокрытия деталей реализации той или иной функции. Есть развитая система конфигов в ScriptableObject (Resources\Configs). Конфиги читаются через интерфейс IConfigService. 

Таким образом, для добавления новых типов монеток или новых эффектов понадобится:
1. Добавить новый конфиг эффекта или типа монетки. В том числе спрайт можно поменять в конфигах
2. Если требуется, добавить новую реализацию IPlayerMovementStrategy
3. Единственный существующий класс который надо изменить - MovementStrategyFactory. Этот класс внедряет новую реализацию IPlayerMovementStrategy.

Для изменения, например, способа спауна монеток можно написать другую реализацию класса CoinSpawnerViewModel. Или, например, можно создать новую реализацию IConfigService чтобы получать конфиги с сервера а не из ScriptableObject.

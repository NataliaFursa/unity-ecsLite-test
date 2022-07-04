#Время работы
Всего на изучение темы ecs ушло 12 часов, так как не была знакома с этой частью. 
На сам проект ушло 7 часов.
Суммарно 19 часов.

#Системы и компоненты
Постаралась разбить логику на 2 части, это системы, которые работают с трансформом или инпутом и системы, 
которые просто выполняют расчёты.

###На сервер
Компоненты
- ButtonComponent
- DoorComponent
- MouseInputComponent
- PlayerComponent

Системы
- ButtonInitSystem
- ButtonPressSystem
- DoorCalculatingSystem
- PlayerCalculatingSystem

Для полноценной логики не хватает классов PlayerInitSystem и DoorInitSystem, а также части с установкой позиции объекту. 
Но в данном случае я так понимаю это клиентская логика. Насчет PlayerInitSystem и DoorInitSystem, там передается ссылка на трансформ объекта, 
поэтому их не вынести из unity.
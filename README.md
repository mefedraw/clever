***Brainz - tg web app наподобие игры clever VK.***

Код для взаимодействия бд и фронтенда.

Спроектирована база данных состоящая из множества таблиц которые нужны для бизнес-логики приложения и функции позволяющие работать с ней путем http запросов к серверу:

![image](https://github.com/mefedraw/CleverGame-ASP-.NET-WEP-API/assets/144416623/20d455ad-e500-4244-91c1-c1863678311d)

https://helloworld9999999.github.io/123/idx_main_page фронтенд частью занимается https://github.com/helloworld9999999


## Описание таблиц базы данных

### DbUserAuth
Содержит телеграм айди пользователя, его username и дату регистрации в приложении (первое нажатие кнопки /start):
- **TgId**: Телеграм айди пользователя.
- **TgUsername**: Username пользователя в Telegram.
- **AuthDate**: Дата регистрации в приложении.

### DbUserTask
Содержит информацию о заданиях пользователей:
- **Id**: Идентификатор задания пользователя.
- **TgId**: Телеграм айди пользователя.
- **TaskId**: Идентификатор задания.
- **IsCompleted**: Статус выполнения задания.

### DbTasksInfo
Содержит информацию о заданиях:
- **TaskId**: Идентификатор задания.
- **Profit**: Выгода от выполнения задания.
- **Text**: Описание задания.
- **Type**: Тип задания.
- **Workload**: Рабочая нагрузка задания.
- **Link**: Ссылка, связанная с заданием.

### DbPoints
Содержит информацию о баллах пользователей:
- **TgId**: Телеграм айди пользователя.
- **Points**: Количество баллов пользователя.

### DbQuests
Содержит информацию о квестах пользователей:
- **TgId**: Телеграм айди пользователя.
- **Completed**: Количество выполненных квестов.

### DbFriendships
Содержит информацию о дружбе между пользователями:
- **Id**: Идентификатор записи дружбы.
- **UserId**: Телеграм айди пользователя, отправившего запрос.
- **FriendId**: Телеграм айди пользователя, получившего запрос.
- **FriendRequestAccepted**: Статус принятия запроса дружбы.
- **FriendsDate**: Дата становления друзьями.


  

# Структура проекта Clever

![image](https://github.com/mefedraw/CleverGame-ASP-.NET-WEP-API/assets/144416623/0f15f33a-decd-4969-a361-fea74eeeef0c)






# Описание API Эндпоинтов

![image](https://github.com/mefedraw/CleverGame-ASP-.NET-WEP-API/assets/144416623/27ccc2af-6527-4974-9c06-94d378d80b03)



## Friend Ship
Управление дружбой между пользователями:
- **POST /api/v1/friends/send-request**: Отправить запрос дружбы.
- **POST /api/v1/friends/accept-request**: Принять запрос дружбы.
- **DELETE /api/v1/friends/remove**: Удалить друга.
- **GET /api/v1/friends/list**: Получить список друзей.
- **GET /api/v1/friends/requests**: Получить список запросов дружбы.

## UserAuth
Управление аутентификацией пользователей:
- **POST /api/v1/auth/user**: Создать нового пользователя.
- **GET /api/v1/auth/exists**: Проверить, существует ли пользователь.
- **GET /api/v1/auth/user-full-auth**: Инициализировать поля с текущим TgId в других таблицах (Points, Quests, UserTasks).

## UserPoints
Управление баллами пользователей:
- **GET /api/v1/points/users-amount**: Получить количество баллов у пользователей.
- **GET /api/v1/points/top-users**: Получить топ пользователей по количеству баллов.
- **PATCH /api/v1/points/add**: Добавить баллы пользователю.
- **PATCH /api/v1/points/remove**: Удалить баллы у пользователя.
- **GET /api/v1/points/place**: Получить место пользователя в рейтинге.

## UserQuests
Управление квестами пользователей:
- **PATCH /api/v1/quests/increase**: Увеличить количество выполненных квестов.
- **GET /api/v1/quests/completed**: Получить количество выполненных квестов.

## UserTask
Управление заданиями пользователей:
- **GET /api/v1/tasks/available**: Получить доступные задания.
- **POST /api/v1/tasks/user-init**: Инициализировать задание для пользователя.
- **PATCH /api/v1/tasks/mark-as-done**: Отметить задание как выполненное.

## UserTasks
Управление информацией о заданиях:
- **POST /api/v1/tasks-info/add**: Добавить новое задание.
- **DELETE /api/v1/tasks-info/delete**: Удалить задание.
- **GET /api/v1/tasks-info/info**: Получить информацию о задании.

Настраиваем БД в Azure:
1) Запускаем Azure Shell
2) Создаем Resource Group:      az group create --name InfestationResourceGroup --location "West Europe". 
Показать доступные FREE хостинги:      az appservice list-locations --sku FREE
3) Создаем SQL server в Azure:       az sql server create --name infestation --resource-group InfestationResourceGroup --location "West Europe" --admin-user TestUser --admin-password password
4) Конфигурим firewall:      az sql server firewall-rule create --resource-group InfestationResourceGroup --server infestation --name AllowAzureIps --start-ip-address 0.0.0.0 --end-ip-address 0.0.0.0    
Если 0.0.0.0 то достучаться к SQL серверу можно только из других ресурсов Azure. Устанавливаем на свой локальный адрес.
5) Создаем БД:      az sql db create --resource-group InfestationResourceGroup --server infestation --name InfestationDB --service-objective S0
6) Формируем строку подключения:      az sql db show-connection-string --client ado.net --server infestation --name InfesttionDB
7) Заменяем строку подключения в проекте и запускаем приложение локально и смотрим что запрос и правда идет к базе в Azure.


Депллоим приложение в Azure:
1) Cоздаем deployment user:      az webapp deployment user set --user-name InfestationTestUser --password Password1
2) Создаем App Service plan:      az appservice plan create --name InfestationServicePlan --resource-group InfestationResourceGroup --sku FREE
3) Создаем web app:      az webapp create --resource-group InfestationResourceGroup --plan InfestationServicePlan --name Infestation --deployment-local-git
4) Конфигурим connection string: az webapp config connection-string set --resource-group InfestationResourceGroup --name <app-name> --settings MyDbConnection="<connection-string>" --connection-string-type SQLAzure
5) Создаем remote для Azure (до этого был только origin):      git remote add azure https://InfestationTestUser@infestation.scm.azurewebsites.net/Infestation.git
6) Пушим изменения в Azure:      git push azure master
7) Смотрим содержимое сервера Kudu:      https://infestation.scm.azurewebsites.net/
8) Делаем изменение и репаблишим.
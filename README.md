# PasswordManager
Simple Password Manager  using WPF, C#, [SQLite](https://en.wikipedia.org/wiki/SQLite) with EntityFramework.

## Usage 
#### Adding data and services

After first time oppening you can add new service (Origin,Steam,Google account) by providing service name in text area:
![image](https://github.com/opermaster/PasswordManager/assets/82831888/93fe90a3-ef3a-448a-bf85-7219a173fed9).

After that add Data(FirstField(Email, Nickname), Password, Choose service in a list) that you want to manage:
![image](https://github.com/opermaster/PasswordManager/assets/82831888/70285c37-e586-41ef-9d68-1bbfda371c3d).

> If you start from adding new data without Services, after pressing Add button you will see window for adding new Service and it automatically choose that new service in a list.

#### Deleting data and services
Deleting happened by providing an Id of Service or Data that you want to delete. Id is number near left side of each record.
On the image below shown procces of deleting second record that contains `test_field` and `test_password`:
![image](https://github.com/opermaster/PasswordManager/assets/82831888/a665d2fe-a067-455b-8d64-9340b95bc72d).

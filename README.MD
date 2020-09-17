
## Evolve proof of concept
* [Evolve concepts](https://evolve-db.netlify.app/concepts/)
* has cli tool
* use repeatable migrations, track changes using file hash, can be use for procedures
* use placeholders to replace part of script
* has transactions for data update (MySql restrictions)

```powershell
# start docker with my sql
docker run -e MYSQL_ROOT_PASSWORD=123456 -p 3306:3306 -d mysql:5.7
# run application
```

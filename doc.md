#Tipy a příkazy pro práci s projektem a jeho nástroji

##Databáze s entity frameworkem
Tutoriál pro EF: ´´´http://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx´´´
1) Nastavte si connection string pro připojení do databáze umístěný v souboru ´appsettings.json´, kde jsou dva connection stringy. 
První je pro vývoj na lokální databázi a druhý je pro produkční verzi, která se bude spouštět na Azure.
Do databáze se lze připojit přes nástroj imístěný v ´View / SQL Server Object Explorer´
Pro první nastavení databáze a následné přidávání migrací je potřeba otevřít ´Package Manager Console´, 
která je v ´View / Other Windows / Package Manager Console´ a sputit příkaz ´Update-Database´

#Uzivatel
test@test.cz / Test1.
# IT-lab (English version below)
Voor het IT-lab, houden we materialen bij die ontleend kunnen worden, het is aan jou om deze functionaliteiten verder te vervolledigen.

## Domein
Het domein is relatief eenvoudig, er zijn slechts 2 klassen die we bijhouden in de databank, namelijk `Material` en `Event`, je mag tijdens het examen geen visibiliteit van de properties aanpassen. Telkens er een ontlening is, houden we een historiek bij van welke student op welke datum dit materiaal ontleende of terugbracht. De student is op zich geen entiteit maar een gewone string.

## Puntenverdeling
De punten staan naast de vragen, indien je solution niet compileert (0/20), code in commentaar wordt niet bekeken.

## Functionaliteiten
Er zijn twee primaire functionaliteiten, het opzoeken van materialen en het toevoegen van materialen die je dient te implementeren. (daarover straks meer)

## Packages
Alle packages zitten reeds in de projecten, je dient geen extra packages via NuGet toe te voegen, mogelijks wel te gebruiken of te implementeren.

## Vraag 1 - Domein (10)
Als een materiaal wordt geleend moet er een event item worden toegevoegd aan de historiek. Zorg dat de volgende unit tests slagen:
- `Material_Should.Have_history_after_borrowing`
- `Material_Should.Not_be_in_stock_after_borrowing`
- `Material_Should.First_be_returned_when_borrowed_again`
> Verander niets aan setters, getters of parameters, implementeer alleen de methode `Material.Borrow` op basis van de tests.

## Vraag 2 - Unit Test (10)
Wanneer de `student` parameter in de `Material.Borrow` functie niet is ingevuld, zou de methode een `ArgumentException` moeten gooien. Valideer dit door de theoretische `Material_Should.Not_Borrow_To_Invalid_Student` unit test te implementeren **en** de test te laten slagen door een `Guard` clausule uit het Ardalis pakket te gebruiken in de `Material.Borrow` methode.

## Vraag 3 - Configurations (10)
In de database zijn er nog enkele problemen die opgelost moeten worden door de `MaterialConfiguration` correct te implementeren. De `naam` van een `Material` moet altijd uniek zijn in de `Material` (let op de enkelvoud vorm) tabel. De `naam` mag niet null zijn en heeft een maximale lengte van 250. De `omschrijving` is echter optioneel met een maximale lengte van 1000. Als een `Material` wordt verwijderd, moet ook de historie uit de database worden verwijderd. Zorg ervoor dat een historiek niet kan bestaan zonder een gelinkt materiaal.

## Vraag 4 - Auth (10)
De create knop bovenaan de `Materials.Index` pagina zou alleen beschikbaar mogen zijn voor `Administrators`. **Daarnaast** mogen enkel `Administrator`s de `Materials.Create.razor` pagina zien.
> Je hoeft je geen zorgen te maken dat de API call niet afgeschermd is voor deze vraag, omdat we gebruik maken van de `FakeAuthenticationProvider`.

## Vraag 5 - Filter (20)
Momenteel worden de materialen opgehaald zonder enige filterfunctionaliteit in de Index pagina. Implementeer de filterfunctionaliteit zodat wanneer op de zoekknop wordt geklikt, een oproep naar de server wordt uitgevoerd en een lijst van materialen wordt teruggestuurd op basis van de zoekterm in het filter. De aanroep wordt alleen getriggerd bij het klikken op de knop (Search), niet bij het typen of het verliezen van de focus.

Gebruik de `MaterialService.GetIndexAsync` methode om het filter gedrag te implementeren. Merk op dat het filteren zelf in de database moet gebeuren en niet in de back-end / front-end. Alleen de materialen met een `naam` die begint met de zoekterm, of de `omschrijving` bevat de `zoekterm` worden geretourneerd in een alfabetische volgorde op basis van de `naam`.

### Eindresultaat -  Zoeken naar materialen
https://user-images.githubusercontent.com/10981553/146948433-8b5e9f5d-8079-42f8-ae38-d84d5b234503.mov

## Vraag 6 - Create (20)
Het aanmaken van materialen is momenteel niet erg functioneel, het is enkel gestyled met behulp van BULMA, hergebruik deze elementen. Implementeer het toevoeg formulier met behulp van de `MaterialDto.Create`, `Materials.Create.razor`, `MaterialController` en `MaterialService.CreateAsync`(back-/frontend). Gebruik een `EditForm` met `FluentValidation` om er zeker van te zijn dat er geen ongeldige materialen kunnen worden aangemaakt, controleer de database regels en maak ze consistent (regels in de databank gelden ook voor de validatie). De `Validator` is een nested class binnen de `MaterialDto.Create`.

Daarnaast dien je ook de Server / API te beschermen tegen ongeldige materialen, doe ook dit aan de hand van het `FluentValidation.AspNetCore` package en middleware.

> Je hoeft geen extra eigenschappen toe te voegen aan de `MaterialDto.Create`.


## Vraag 7 - Notificaties (10)
Wanneer een materiaal is aangemaakt wordt de gebruiker terug genavigeerd naar de `Material.Index.razor` pagina ook moet er een notificatie worden getoond aan de gebruiker. Gebruik [Blazored.Toast](https://github.com/Blazored/Toast) om een succes notifcatie te tonen "Materiaal is toegevoegd!", gebruik de README.md van het project om de functionaliteit te implementeren.

### Eindresultaat -  Toevoegen van materiaal met validatie en notificatie
https://user-images.githubusercontent.com/10981553/146948409-5be6e47c-b60d-4bcb-9db5-4b011d29908e.mov

## Vraag 8 - Theorie (10)
Beantwoord de volgende vragen in-line in deze README.md:
1. Waarom is het not-done om voor de toevoeg functionaliteit de `MaterialDTO.Index` klasse te herbruiken? 
   - Antwoord:
3. Naar de API wordt een id-token opgestuurd bij elk request vanuit de client. Leg uit waarom dit juist of fout is.
   - Antwoord:

---

# IT-lab (English Version)
For the IT lab, we keep materials that can be borrowed by students, it is up to you to further complete these functionalities.

## Domain
The domain is relatively simple, there are only 2 classes that we keep in the database, namely `Material` and `Event`, you are not allowed to change the visibility of the properties during the exam. Whenever there is a borrowing, we keep a history of which student borrowed or returned this material on which date. The student itself is not an entity but an ordinary string.

## Points distribution
Points are next to the questions, if your solution does not compile (0/20), code in comments does not count for scoring.

## Functionalities
There are two primary functionalities, looking up materials and adding materials that you need to implement. (More on that later)

## Packages
All packages are already in the projects, you don't need to add any additional packages through NuGet, possibly use or implement them.

## Question 1 - Domain (10)
If a material is borrowed, an event item must be added to the history. Make sure the following unit tests pass:
- `Material_Should.Have_history_after_borrowing`.
- `Material_Should.Not_be_in_stock_after_borrowing`
- `Material_Should.First_be_returned_when_borrowed_again`
> Don't change anything about setters, getters or parameters, just implement the method `Material.Borrow` based on the tests.

## Question 2 - Unit Test (10)
When the `student` parameter in the `Material.Borrow` function is not filled in, the method should throw an `ArgumentException`. Validate this by implementing the theoretical `Material_Should.Not_Borrow_To_Invalid_Student` unit test **and** passing the test by using a `Guard` clause from the Ardalis package in the `Material.Borrow` method.

## Question 3 - Configurations (10)
In the database, there are still some problems that need to be solved by implementing the `MaterialConfiguration` correctly. The `name` of a `Material` must always be unique in the `Material` (note the singular form) table. The `name` cannot be null and has a maximum length of 250. However, the `description` is optional with a maximum length of 1000. If a `Material` is deleted, the history must also be deleted from the database. Make sure that a history cannot exist without a linked material.

## Question 4 - Auth (10)
The create button at the top of the `Materials.Index` page should only be available to `Administrators`. **In addition** only `Administrator`s should see the `Materials.Create.razor` page.
> You don`t have to worry that the API calls is not protected for this query, because we are using the `FakeAuthenticationProvider`.

## Question 5 - Filter (20)
Currently, materials are retrieved without any filter functionality in the Index page. Implement filter functionality so that when the search button is clicked, a call is made to the server and a list of materials is returned based on the search term in the filter. The call is triggered only when the button (Search) is clicked, not when typing or losing focus.

Use the `MaterialService.GetIndexAsync` method to implement the filtering behavior. Note that the filtering itself must be done in the database and not in the back-end / front-end. Only the materials with a `name` that starts with the search term, or the `description` contains the `search term` are returned in an alphabetical order based on the `name`.

### Result -  Searching for materials
https://user-images.githubusercontent.com/10981553/146948433-8b5e9f5d-8079-42f8-ae38-d84d5b234503.mov

## Question 6 - Create (20)
Creating materials is currently not very functional, it is only styled using BULMA, reuse these elements. Implement the add form using the `MaterialDto.Create`, `Materials.Create.razor`, `MaterialController` and `MaterialService.CreateAsync` (back/frontend). Use an `EditForm` with `FluentValidation` to ensure that no invalid materials can be created, check the database rules and make them consistent (rules in the database also apply to validation). The `Validator` is a nested class within the `MaterialDto.Create`.

In addition, you also need to protect the Server / API from invalid materials being created, do this using the `FluentValidation.AspNetCore` package and middleware.

> You do not need to add any additional properties to the `MaterialDto.Create`.


## Question 7 - Notifications (10)
When a material is created the user is navigated back to the `Material.Index.razor` page also a notification should be shown to the user. Use [Blazored.Toast](https://github.com/Blazored/Toast) to display a success notifcation "Material has been added!", use the README.md of the project to implement the functionality.

### Result -  Adding materials with validation and notification
https://user-images.githubusercontent.com/10981553/146948409-5be6e47c-b60d-4bcb-9db5-4b011d29908e.mov

## Question 8 - Theory (10)
Answer the following questions in-line in this README.md:
1. Why is it not-done to reuse the `MaterialDTO.Index` class for the add/create functionality? 
   - Answer:
3. An id token is sent to the API with each request from the client. Explain why this is right or wrong.
   - Answer:


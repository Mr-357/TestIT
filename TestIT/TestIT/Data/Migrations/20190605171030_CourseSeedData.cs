using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class CourseSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33218622-37d8-4f3e-8ac0-bd34b4acfa0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8faf6aa6-8c29-460e-8882-37bfcc693147");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a9319eb-9060-4624-978f-9efedcf9dfb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5569518-fe56-4631-a66d-bd1b01b4ceda");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "df2f4ded-1acd-47d9-b75b-218a19062fc6", "148580b8-9326-4681-882a-b4eda7ff9323", "Admin", "ADMIN" },
                    { "81fd2fec-b17a-4c72-8686-25f5d77e0909", "e2c8dbb4-523b-4abc-9e4c-3811007d8764", "Moderator", "MODERATOR" },
                    { "37278f11-1b01-4a26-801b-bae64fb471dd", "e2e98087-b2b7-4e45-b714-7237f7503b58", "Student", "STUDENT" },
                    { "1ccc36cd-2423-418d-b13c-dab0272fef0d", "1c9959c3-883e-414d-b668-1d1b2e720817", "Profesor", "PROFESOR" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Description", "Module", "Name", "SchoolYear", "Short" },
                values: new object[,]
                {
                    { 42, "Na kraju kursa student će biti u stanju da razume osnovne probleme, moguća rešenja i pravce istraživanja u veštačkoj inteligenciji. Student će biti u stanju da odgovori na pitanja: šta je veštačka inteligencija, od čega se sastoje ekspertni sistemi, šta je inženjerstvo znanja i koji se formalizmi koriste za predstavljanje znanja. Student će biti osposobljen da prepozna probleme veštačke inteligencije i načine njihovog rešavanja preko algoritama iz različitih oblasti veštačke inteligencije koje je savladao. Student će biti osposebljen da razvije programe bazirane na tehnikama veštačke inteligencije u Lisp-u i drugim programskim jezicima.", "RII", "Veštačka inteligencija", "Cetvrta", "VI" },
                    { 41, "Model podataka za Skladišta podataka. Koncepti, algoritmi, tehnike i sistemi za skladištenje podataka i otkrivanje znanja. Arhitekture skladišta podataka. Implementacija skladišta podataka: ekstrakcija podataka, prečišćavanje, transformacija, data cube i učitavanje. OLAP obrada upita. Proces otkrivanja znanja. Arhitektura sistema za otkrivanje znanja. Veza sistema za otkrivanje znanja sa skladištima podataka i OLAP sistemima. Prethodna obrada podataka. Tehnike otkrivanja znanja. Upitni jezik za otkrivanje znanja. Klasifikacija i predikcija. Analiza klastera. Otkrivanje znanja kod kompleksnih tipova podataka (iz prostornih i multimedijalnih baza podataka). Aplikacije za otkrivanje znanja i trendovi razvoja - otkrivanje znanja u tekstu, na Vebu, pretraživanje Veba, rang stranica, Veb spam.", "RII", "Skladištenje podataka i otkrivanje znanja", "Cetvrta", "SPOZ" },
                    { 40, "Proces i tok projektovanja. Okruženja za simulaciju i sintezu. Verifikacija kola. Projektovanje aritmetičkih kola. VHDL opisi osnovnih digitalnh kola u VHDL-u. Kompromisi u projektovanju. Projektovanje složenijih računarskih komponenti. VHDL opis i sinteza. Model toka podataka.  Izračunavanja vođena podacima. Projektovanje i implementacija procesora baziranih na toku podataka u Java okruženju. Projektovanje procesne jedinice. Projektovanje upravljačkih modula. Projektovanje memorijskog sistema. Projektovanje sistema magistrala. Projektovanje ulazno-izlaznog podsistema. Upravljanje potrošnjom kola. Projektovanje procesora posebne namene.", "RII", "Projektovanje računarskog hardvera", "Cetvrta", "PRH" },
                    { 39, "Potrebe za paralelnim računarskim sistemima (PRS).Klasifikacija PRS. Performanse računarskih sistema.  Ubrzanje. Amdalov zakon. Efikasnost. Efektivni paralelni algoritmi. Princip neograničenog paralellizma. Stepen paralelizma. Granularnost programa. Zavisnosti u programu. Zavisnosti po podacima. Prave zavisnosti. Antizavisnosti. Izlazne zavisnosti. Eliminacija zavisnosti. Kontrolne zavisnosti. Vektorski računari. Arhitekture. Vektorizacija petlji. Procesorska polja.  Maskiranje procesnih elemenata. Paralelizacija ugnježđenih petlji. Primeri SIMD algoritama. Sprežne mreže (SM). Statičke SM. Dinamičke SM: jednostepene i višestepene.Rutiranje. Muliprocesori i multiračunari.  Arbitraža na magistrali. Keš koherencija. Hardverski protokoli keš koherencije: njuškala (Snoopy) i direktorijumske šeme. Komunikacija i sinhronizacija procesa u MIMD sistemima: semafori, monitori, tehnika slanja poruka. Primeri algoritama za MIMD sisteme. Multiprocesori na čipu.", "RII", "Paralelni sistemi", "Cetvrta", "PS" },
                    { 38, "Savremene platforme za podršku učenju; istorija tehnologija za podršku učenju i pojam učenja podržanog tehnologijom. E-učenje, m-učenje, e-testiranje i personalizovano učenje i testiranje. Pristupi učenju i vrste tehnološke podrške učenju. Hardverska i softverska infrastruktura platformi za podršku učenju. Sistemi za organizaciju učenja (LMS); virtuelna okruženja za učenje (VLE); multimedijalne i multimodalne komponente za učenje; inteligentni tutorski sistemi.", "RII", "Tehnologije za podršku učenju", "Cetvrta", "TPU" },
                    { 36, "Elementi kriptologije, kriptografije i kriptoanalize. Autorizovani pristup. Metode identifikacije. Razvoj sistema sa autorizovanim pristupom. Simetrična kriptografija. Javni i tajni ključ. Hash funkcije. Metoda napada na zaštićeni sistem. Sertifikati, održavanje i izdavanje sertifikata. Osnovni sigurnosni protokoli. Tipovi malware programa.", "RII", "Zaštita informacija", "Cetvrta", "ZI" },
                    { 43, "Uvod u mobilne sisteme i servise. Mobilni računarsko/komunikacioni uređaji, pametni telefoni, tableti. Bežične mreže i protokoli. Operativni sistemi, middleware platforme i programska okruženja za razvoj mobilnih aplikacija i servisa. Arhitektura i projektovanje mobilnih aplikacija i servisa. Mobilne Web aplikacije i Mobile 2.0. Korisnički interfejsi mobilnih aplikacija i servisa. Upravljanje podacima u mobilnim aplikacijama i mobilne baze podataka. Mobilna sigurnost. Mobilna razmena poruka. Mobilno pozicioniranje. Lokaciono-zasnovani i kontekstno-svesni servisi. Savremene aplikacije: mobilno poslovanje, inteligentni transportni sistemi, turistički vodiči, mobilna zdravstvena zaštita, mobilne igre, upravljanje vanrednim situacijama, itd.", "RII", "Mobilni sistemi i servisi", "Cetvrta", "MSS" },
                    { 35, "Formalni jezici i gramatike, Automati kao uređaji za prepoznavanje jezika. Leksički analizator. Sintaksna analiza. LLk gramatike i analizatori. Operatorske ramatike. LR analizatori. Generatori analizatora (Lex i Yacc). Međukodovi. Lokalna optimizacija koda. Analiza na nivou tipova podataka. Oprimizacija koda. Statička i dinamička raspodela memorije. Interpretatori. Asembler i makroasembler.", "RII", "Programski prevodioci", "Cetvrta", "PP" },
                    { 34, "Uvod u interaktivnu računarsku grafiku i sisteme za računarsku grafiku. Hardver za računarsku grafiku. Rasterski grafički algoritmi za crtanje, ispunu i isecanje 2D primitiva (linija, krug elipsa). 2D i 3D geometrijske transformacije. Komponovanje transformacija. Algoritmi za ostvarivanje realnosti prikaza. Modeli boja. Svetlo i modeli osvetljenja. Modeli senčenja. Algoritmi za generisanje senki. Modeliranje krivih i površi (Splajn, Bezierove i NURBS krive i površi). Alati i softver za računarsku grafiku. Grafički API (GDI, GDI+, OpenGL). Interaktivno grafičko programiranje.", "RII", "Računarska grafika", "Cetvrta", "RG" },
                    { 33, "Uvodne teme: tradicionalne relacione baze podataka, transakcije, ACID svojstva, oporavak i kontrola konkurencije. Distribuirane baze podataka, moderni trendovi i problemi, skalabilnost i problemi realizacije ACID svojstava kod takvih sistema. Interoperabilnost i integracija informacija. Medijatori, Skladišta podataka, Federativne baze podataka. Objektne i objektno-relacione baze podataka - pojam, osnovni koncepti Baze podataka u Web okruženju. Semantički Web i baze podataka – pojam, osnovni koncepti, ontologije. XML i baze podataka. Relacione baze podataka i XML. Native XML baze podataka. NoSQL baze podataka: pojam, osnovni koncepti.", "RII", "Napredne baze podataka", "Cetvrta", "NBP" },
                    { 32, "Uvod u arhitekturu i projektovanje softvera. Osnovni principi i metode projektovanja softvera. Projektovanje softvera primenom projektnih obrazaca. Refaktoring projektovanja u projektne obrasce. Arhitektura softvera - osnovni principi i metode. Modularnost softverskog sistema. Sprega, kohezija, interfejsi i konektori softverskih komponenti. Arhitekturni stilovi i obrasci. Razvoj i dokumentovanje arhitekture softvera. Softverske komponente, aplikacioni okviri i middleware platforme. Arhitektura enterprise aplikacija. Servisno-orijentisana arhitektura i Web servisi. Modelom vođena arhitektura (Model Driven Architecture - MDA) i razvoj softvera.", "RII", "Arhitektura i projektovanje softvera", "Cetvrta", "AIPS" },
                    { 37, "Uvod i pregled oblasti. Mediji. Zahtevi multimedijalnog procesiranja. Mreže za multimediju i protokoli za striming informacija. Formati za zvuk, tekst, mirnu i pokretnu sliku. Metode za kompresiju slike, audio i video signala. Potpuni MPEG-4 standard za multimediju. Drugi MPEG standardi. Zaštita multimedijalnih sadržaja i metode za wathermarking. Vrste multimedijalnih sistema i primene (npr. videokonferencije, učenje na zahtev, itd.). Arhitekture multimedijalnih sistema. Performanse multimedijalnih sistema. Mobilni multimedijalni sistemi. Perspektive razvoja multimedijalnih sistema.", "RII", "Multimedijalni sistemi", "Cetvrta", "MS" },
                    { 44, "Cilj predmeta je upoznavanje studenata sa naprednim distribuiranim algoritmima i strukturama podataka, koje omogućavaju razumevanje koncepta blokčein sistema, kao i sa naprednim tehnologijama koje omogućavaju implementaciju ovih sistema.Očekuje se da student stekne potrebno znanje za razumevanje principa i koncepata vezanih za blokčein tehnologiju, kao i da može da primeni dostupne alate i okruženja, i implementira privatne i javne blokčein sisteme samostalno ili u dostupnim okruženjima. Očekuje se da student ovlada tehnologijama kako bi mogao da samostalno razvije distribuirane aplikacije na Ethereum blokčein platformi.Osnovni koncepti blokčeina. Decentralizacija. Komunikacija kod decentralizovanih sistema. Elementi kriptografije, kriptografske primitive. Sistemi sa javnim ključem, PKI, RSA, ECC. Heš funkcije, SHA-1, SHA-2, MD5. Upotreba OpenSSL. Otpornost na greške i konsenzus algoritmi. Kriptovalute i kriptoekonomija. Javni i privatni blokčein sistemi. Bitkoin. Digitalni ključevi i adrese. Transakcije. Rudarenje, CPU, GPU, FPGA, ASIC. Alternativne valute. Ethereum. Pametni ugovori. Programiranje u Ethereum-u. Imllementacija Ethereum sistema. Razvojni alati. Hyperlegder. Primena blokčein sistema.", "RII", "Blokchain tehnologije", "Master", "BT" },
                    { 46, "Sticanje znanja o tehnikama za obradu slike i osposobljavanje studenta za samostalnu primenu naučenih tehnika za rešavanje realnih problema", "RII", "Napredne tehnike za obradu slike", "Master", "NTOS" },
                    { 31, "Osnovni koncepti umrežavanja. Komutacija na nivoima 2 i 3. Karakteristike pasivne i aktivne mrežne opreme. Mrežni modeli, hijerarhijski model projektovanja mreža. Planiranje osnovnih servisa, planiranje distribuiranih servisa, planiranje lokalnih servisa, planiranje pouzdanosti mreže. Zahtevi, identifikacija i validacija. Dizajn mreža. Logički dizajn, fizički dizajn, testiranje, optimizacija i dokumentacija mreže. Proces projektovanja i implementacije mreže. Tipični modeli za implementaciju malih i srednjih mreža. Virtualne mreže. Trankovi. ISL i IEEE802.1 protokoli i enkapsulacija. VTP. Redundantne topologije. Protokoli za implementaciju redundantnih topologija na drugom nivou OSI modela. STP i Rapid STPprotokoli. Rutiranje između virtualnih mreža. Virtualni interfejsi. Osnovni koncepti internet telefonije. Bežične mreže, standardi, principi projektovanja, roming servis za mobilne uređaje. Bezbednost mreža. Tipični scenariji napada. Osnovni koncepti za povećanje bezbednosti mreža.", "RII", "Projektovanje računarskih mreža", "Cetvrta", "PRM" },
                    { 47, "Uvođenje studenata u oblast virtuelne i proširene realnosti i upoznavanje sa osnovnih uređajima, algoritmima i tehnikama koje se koriste kod realizacije ovih sistem", "RII", "Sistemi virtuelne i proširene realnosti", "Master", "SVPV" },
                    { 48, "Upoznavanje sa pojmom medicinske informatike i oblastima i načinima primene informatike u medicini", "RII", "Medicinska informatika", "Master", "MI" },
                    { 49, "Pristupi mašinskog učenja: induktivno učenje, analitičko učenje. Izbor primera za sticanje iskustva, izbor i predstavljanje ciljne funkcije. Učenje kao pretraživanje i algoritmi za pretraživanje prostora potencijanih hipoteza. Generisanje stabla odlučivanja. Učenje zasnovano na instancama (case-based). Fazi logika. Veštačke neuronske mreže. Arhitekture veštačkih neuronskih mreža, aktivacione funkcije, algoritmi učenja, neuronske mreže sa direktnim prostiranjem signala, rekurentne neuronske mreže. Fazi neuronske mreže. Evoluciono računarstvo. Evoluciono programiranje, evolucione strategije, genetsko programiranje, genetski algoritmi i optimizacije, operatori genetskih algoritama, integracija genetskih algoritama i neuronskih mreža.", "RII", "Soft kompjuting", "Master", "SK" },
                    { 50, "Upoznavanje sa arhitekturom 3D grafičkih protočnih sistema, njihovim programibilnim stepenima i načinom njihovog programiranja", "RII", "3D grafički protočni sistemi", "Master", "3D" },
                    { 51, "Razumevanje koncepata i tehnologija računarstva visokih performansi kao i sticanje teorijskih i praktičnih znanja koja omogućavaju razvoj i analizu aplikacija visokih performansi na savremenim  računarskim arhitekturama. ", "RII", "Računarstvo visokih performansi", "Master", "RVP" },
                    { 52, "Cilj predmeta je da studenti steknu uvid u potencijalne bezbedonosne slabosti mreža i dobiju osnovna znanja za povećanje bezbednosti, kao i potrebna aplikativna znanja i veštine koje mogu primeniti u cilju povećanja bezbednosti računarskih mreža", "RII", "Bezbednost računarskih mreža", "Master", "BRM" },
                    { 53, "forenzikuUpoznavanje sa procesom identifikacije, očuvanja i analize digitalnih dokaza, kao i njihovu pripremu za prezentaciju na sudu u odgovarajućem postupku na forenzički ispravan način.", "RII", "Digitalna forenzika", "Master", "DF" },
                    { 54, "Cilj predmeta je da studenti steknu znanja o o projektovanju embeded sistema.", "RII", "Embeded sistemi", "Master", "ES" },
                    { 55, "Na kraju kursa student će biti u stanju da razume aktuelne probleme implementacije inteligentnih sistema, kao i buduće pravce istraživanja i razvoja u veštačkoj inteligenciji. Student će biti u stanju da odgovori na izazove oko izbora i projektovanja pojednih delova inteligentnog sistema. Student će biti osposobljen da prepozna probleme realizacije distribuiranih inteligentnih sistema, problem semantičke integracije informacija, i da implementira neka rešenja zasnovana na ontologijama.", "RII", "Inteligentni sistemi", "Master", "IS" },
                    { 56, "Teorijska i praktična znanja o konceptima, načinima rešavanja, projektovanju i implementaciji osnovnih elemenata interoperabilnosti sistema i integracije informacija.", "RII", "Interoperabilnost i integracija informacija", "Master", "III" },
                    { 57, "Uvođenje studenata u oblast inženjerstva zahteva i upoznavanje sa principima upravljanja zahtevima kao i sa osnovnim modelima inženjerstva zahteva.", "RII", "Inženjerstvo zahteva", "Master", "IZ" },
                    { 58, "Sticanje znanja o XML i Web servisima za potrebe samostalnog razvoja Web 2.0 zasnovanih aplikacija", "RII", "Napredne Web tehnologije", "Master", "NWT" },
                    { 45, "Cilj ovog predmeta je da upozna studente sa specifičnostima razvoja medicinskih informacionih sistema, kao i sa različitim kategorijama medicinskog softvera i pratećom zakonskom regulativom i standardima. Takođe, ovaj predmet treba da pruži studentima i uvid u ceo proces razvoja kroz praktične vežbe i razvoj samostalnog softverskog projekta", "RII", "Medicinski informacioni sistemi", "Master", "MIS" },
                    { 30, "Inženjerska etika (IEEE Etički kod). Domaća i međunarodna pravna regulativa. Autorska prava. Patenti. Zaštita proizvoda. Licenciranje proizvoda. Tehnike zaštitte. Garancija. Ugovaranje. Procedure javnih nabavki. Informatički kriminal. Računarsko veštaćenje.", "RII", "Socijalni i pravni aspekti informatike", "Cetvrta", "SPAI" },
                    { 28, "Uvod i istorijat oblasti računarskog vida. Operacije nad slikama. Računanje i upotreba histograma. Binarizacija i segmentacija slika. Morfološke operacije. Filtriranja slika. Detekcija ivica i uglova. Detekcija kontura i linija. Detekcija krugova i elipsi. Detektovanje i uparivanje karakterističnih tačaka. Transformacija slika. Kalibracija kamere (korekcija radijalne distorzije). Procena projekcionih relacija između para slika. Obrada video sekvenci (detekcija pokreta, identifikacija i praćenje objekata). Metode za rekonstrukciju trodimenzionalnih scena.", "RII", "Računarski vid", "Cetvrta", "RV" },
                    { 59, "Razumevanje tehnologija, pravaca razvoja, kao i dizajna i implementacije savremenih operativnih sistema i sistemskog softvera", "RII", "Napredni operativni sistemi", "Master", "NOS" },
                    { 1, "Brojni sistemi i predstavljanje podataka u računaru. Bool-ova algebra. Prekidačke funkcije. Kombinacione prekidačke mreže. Analiza i sinteza kombinacionih prekidačkih mreža. Standardni kombinacioni moduli. Sekvencijalne prekidačke mreže. Standardni sekvencijalni moduli. Arhitektura računara. Organizacija centralnog procesora i elementi asemblerskog jezika. Ulazno-izlazni uređaji. Softver računara - sisremski i aplikativni softver, razvoj softvera. Računarske mreže, Internet i Veb.", "RII", "Uvod u racunarstvo", "Prva", "UUR" },
                    { 2, "Algoritmi, osnovni pojmovi i način predstavljanja algoritma. Grafičko predstavljanje algoritama. Upravljačke strukture. Ugnježdene upravljačke strukture. Tipovi i strukture podataka. Osnovni tipovi podataka. Strukturni tipovi podataka: linearni, nelinearni. Primeri algoritama. Programski jezik C. Faze u razvoju C programa. Azbuka C-a i struktura programa. Tipovi podataka u C-u. Konstante. Operatori. Prioritet operatora. Struktura C programa i f-ja main. Standardni ulaz i izlaz. Kontrola toka programa. Nizovi i matrice. Dekompozicija i funkcije u C-u. Prenos parametara. Parametri funkcije main. Rekurzivne funkcije. Standardna biblioteka C funkcija. Izvedeni tipovi podataka: pokazivači, strukture, ugneždene strukture, samoreferencirajuće strukture, unije. Dinamička alokacija memorije. Preprocesorske direktive. Memorijske klase identifikatora. Stringovi. Nizovi pokazivača, matrica stringova. Ulaz, izlaz i rad sa fajlovima. Tekstualni i binarni fajlovi.", "RII", "Algoritmi i programiranje", "Prva", "AIP" },
                    { 3, "Matematička logika. Iskazni račun. Iskazne formule. Koegzistencija i logičke posledice.Minimizacija zagrada i logičkih veznika. Normalne forme. Skupovi. Predstavljanje.Operacije sa skupovima. Princip sume. Princip uključenja-isključenja. partitivni skup. Razbijanje skupa.Dekartov proizvod. Princip proizvoda. Relacije. Matrično predstavljanje. Zatvaranje relacija. relacija poretka i ekvivalencije.Leksikografsko uređenje. Funkcije. Principi injekcije, sirjekcije, bijekcije, komplementa. Dirihleov princip. Nizovi. Funkcije generatrise.Rekurentni nizovi. Rešavanje linearnih rekurentnih relacija. Fibonačijevi, Katalanovi i Stirlingovi brojevi. Konačne razlike i sume. Permanent.Izračunavanje i osobine. Permanent matrica u specijalnom obliku. Sistemi različitih predstavnika. Celi brojevi. Deljivost. NZS i NZD. Euklidov algoritam.Diofantove jednačine. Modularne jednačine. Kineska teorema o ostacima. Ojlerova funkcija. Mala Fermaova teorema. Verižni razlomci. Modularna aritmetika.", "RII", "Diskretna matematika", "Druga", "DM" },
                    { 4, "Pregled osnovnih komponenti računarskih sistema. Organizacija računarskog sistema. Procesor. Memorijski podsistem. Magistrale. Ulazno/izlazni (U/I) podsistem. Struktura procesora i njegove funkcije. Registarski skup. Pribavljanje i izvršenje instrukcija. Aritmetičko-logička jedinica (realizacije računarskih operacija). Predstavljanje numeričkih podataka. Predstavljanje nenumeričkih podataka. Sistem prekida. Programski model mikroprocesora. Makro naredbe. Procedure. Potprogrami i prenos parametara. Prekidni programi. Organizacija ulaza/izlaza. Paralelni i serijski U/I. U/I uređaji. Programirani U/I. U/I upravljan prekidima. U/I direktnim pristupom memoriji.", "RII", "Racunarski sistemi", "Druga", "RS" },
                    { 5, "Pregled tehnika programiranja. Modelovanje problema. Klase. Objekti. Modelovanje problema klasama. Definisanje klase. Pristup članovima klase. Scope. Razdvajanje interfejsa od implementacije. Inline funkcije. Konstruktori. Destruktori. Redosled poziva konstruktora i destruktora. Copy konstruktori. Prijatelji klasa. Prijateljske funkcije. Prijateljske klase. Preklapanje operatora. Operatorske funkcije. Bočni efekti i veze izmedju operatorskih funkcija. Izbor povratnih vrednosti operatorskih funkcija. Izvođenje, nasleđivanje, specijalizacija, generalizacija. Definisanje izvedene klase. Vidljivost i prava pristupa. Načini izvođenja. Konstruktori i destruktori izvedenih klasa. Konverzija pokazivača i referenci. Polimorfizam. Virtuelne funkcije. Čiste virtuelne funkcije. Apstraktne klase. Virtuelni destruktor.  Nizovi i izvedene klase. Višestruko nasleđivanje. Konstruktori i destruktori kod višestrukog nasleđivanja. Višestruki podobjekti. Virtuelne osnovne klase. Generički mehanizam-šabloni.  Generisanje funkcija. Generisanje klasa. Obrada izuzetaka. Izazivanje izuzetaka. Prihvatanje izuzetaka. Neprihvaćeni izuzeci. Ulazno-izlazni tokovi. Standardni tokovi. Klase za ulazen tokove. Konstruisanje objekata ulaznih tokova. Operacije ulaznog toka. Preklapanje operatroa ekstrakcije. Izlazni tokovi. Upotreba operatora umetanja. Formatiranje izlaza. Operacije izlaznog toka. Preklapanje operatora umetanja za korisničke tipove. Standardna biblioteka. Namespace. Kontejnerske klase (vektori, liste, stekovi, redovi, mape, skupovi, ...). Klase: Iteratori, Algoritmi. String.", "RII", "Objektno orijentisano programiranje", "Druga", "OOP" },
                    { 6, "Osnove prekidačke teorije. Algebarske strukture za logičko projektovanje. Predstavljanje diskretnih funkcija, klasični pristupi, funkcionalni razvoji, dijagrami odlučivanja. Klasifikacija prekidačkih funkcija. Klasični pristupi realizaciji prekidačkih funkcija. Multiplekserska sinteza. Realizacija prekidačkih funkcija programabilnim kolima, PLA, realizacija primenom ROM-a, FPGA. Bulova diferenca i primene u otkrivanju grešaka. Lako testabilne realizacije. Sekvencijalne mreže, kodiranje i optimizacija. Realizacija sekvencijalnih mreža.", "RII", "Logicko projektovanje", "Druga", "LP" },
                    { 7, "Implementacija procesora: putevi podataka procesora i upravljačka jedinica. Hardverska i mikroprogramska realizacija upravljačke jedinice. Protočno izvršavanje instrukcija. Strukturni hazardi. Hazardi podataka. Hazardi upravljanja. Izbegavanje hazarda podataka premošćavanjem. Izbegavanje hazarda podataka planiranjem instrukcija. Smanjenje cene grananja. Proširenje protočnog sistema za rukovanje operacijama sa više ciklusa. Superskalarni procesori. VLIW procesori. Izvršavanje aritmetičkih operacija. Tehnike za ubrzanje celobrojnog sabiranja, množenja i deljenja. Operacije sa podacima sa pokretnom zapetom. Protočna organizacija aritmetičke jedinice. Elementi memorijskog sistema. Hijerarhijska organizacija memorijskog sistema. Keš memorija procesora. Glavna memorija. Keš memorija diskova. Virtuelna memorija.", "RII", "Arhitektura i organizacija racunara", "Druga", "AOR" },
                    { 8, "Razvoj programskih jezika. Uloga programskih prevodioca.  Formalni opis jezika. Elementi jezika. Sistem tipova podataka.  Strukturni tipovi podataka. Dinamički tipovi podataka. Osnovne upravljačke strukture. Potprogrami i moduli. Apstrakcija. Objektno orijentisani jezici, Jezici za konkurentno programiranje. Obrada izuzetaka. Mehanizmi niskog nivoa. Integrisana razvojna okruženja. Funkcionalni jezici. Jezici za Veb programiranje.", "RII", "Programski jezici", "Druga", "PJ" },
                    { 9, "Definicija i pregled struktura podataka, strukture podataka u sofverskom inženjerstvu, kategorizacija struktura podataka, pseudokod, složenost i ocena složenosti algoritama. Nizovi: difinicija nizova, operacije sa nizovima, tipovi podataka string. Lančane liste: definicija strukture, tipovi lančanih listi - jednostruko povezane, dvostruko povezane, ciklične, osnovne operacije (obilazak, dodavanje, brisanje), napredne operacije, statička i dinamička implementacija lančanih listi. Red, Magacin, Dek: definicija strukture, statička i dinamička implementacija reda, magacina i deka, osnovne operacije (obilazak, dodavanje, brisanje) kod statičke i dinamičke implementacije. Heš tablice: definicija strukture, definicija pojmova (heš funkcija, kolizija i sinonimi), rešavanje kolizije (otvoreno adresiranje, ulančavanje sinonima), implementacija heš tablice, osnovne operacije (traženje, čitanje/brisanje). Stabla: osnovni pojmovi, binarna i opšta stabla, operacije (obilazak, dodavanje i brisanje čvorova), uređena binarna stabla, statička i dinamička implementacija stabla, Heap (gomila) – način formiranja, primena (sortiranje), stabla traženja, B, B*, B++ stabla. Grafovi: definicije pojmova, statička (matrice susedstva, matrice incidencije) i dinamička reprezentacija grafa (lančane strukture), operacije za staičku i dinamičku implementaciju, obilazak grafa po širini i po dubini, najkraći put u grafu za statičku i dinamičku reprezentaciju. Datoteke: sekvencijalne, direktne, indeks-sekvencijalne, indeks-nesekvencijalne, datoteke sa više knjučeva. Rasuto adresiranje.", "RII", "Strukture podataka", "Druga", "SP" },
                    { 10, "Uvod u baze podataka: osnovni pojmovi (podatak, informacija, baza podataka, sistem za upravljanje bazama podataka, sistem baza podataka, aplikacije nad bazom podataka), konvencionalna obrada i obrada zasnovana na bazama podataka, kategorizacija korisnika baza podataka, prednosti i nedostaci, istorijat razvoja. Modeli podataka: nivoi apstrakcije kod DBMSa, pojam modela podataka i njegove komponente, koncpetualno projektovanje baze podataka, (E)ER model podataka, kocepti (E)ER modela i grafička notacija ((E)ER dijagram), projektovanje baze podataka korišćenjem (E)ER modela podataka. Relacioni model: koncepti relacionog modela, strukturna i integritetna komponenta, šema relacije, pojava relacije, ključ relacije, specifikacija ograničenja, SQL DDL naredbe. Relaciona algebra: relaciona algebra, operacije relacione algebre – selekcija, projekcija, spoj i vrste spojeva, unija, presek, razlika, Dekartov proizvod, upiti relacione algebre, primeri upita. Funkcionalne zavisnosti: definicija funkcionalni zavisnosti, pravila izvođenja funkcionalni zavisnosti, zatvarač skupa funkcionalnih zavisnosti, zatvarač skupa atributa, određivanje jednog ključa šeme relacije, nalaženje svih ključeva. Analiza šeme relacije: proces nalize i kvalitet projektovane šeme baze podataka, anomalije kod loše projektovanih baza podataka, dekompozicija relacija kod normalizacije i svojstva. Normalizacija: svrha normalizacije i normalne forme, definicije i test normalnih formi (prva, druga, treća normalna forma i Boyce-Codd-ova normalna forma), postupak normalizacije i primeri iz prakse. Uvod u transakcionu obradu: pojam transakcija, ACID svojstva transakcija, transakcije na nivou DBMS-a i potencijalni problemi kod ažururanja, transakcije i oporavak baze podataka. Arhitektura sistema baza podataka, pregled: monolitni sistemi, višekorisnički, klijent-server sistemi, dvoslojne i troslojne ahitekture, paralelni/distribuirani server baza podataka, fragmentacija podataka.", "RII", "Baze podataka", "Druga", "BP" },
                    { 11, "Definicije. Stepeni čvorova. Predstavljanje. Dijametar, ekscentricitet, radijus, centar. Grafovski nizovi. Putevi u grafu. Povezanost. Komponente povezanosti. Najkraći putevi. Graf grana. Bipartitni graf. Izomorfizam grafova. Spektar grafa. Ojlerovi grafovi. Flerijev algoritam. Problem kineskog poštara. Hamiltonovi grafovi. Problem trgovačkog putnika. Algoritam najbližeg suseda. Operacije sa grafovima. Planarni grafovi. Dualni graf. Teorema Ojlera. Stabla. Ciklomatski broj. Sprežna stabla. Minimalna sprežna stabla. Primov, Kraskalov, Mags-Plotkinov algoritam. Transformacije sprežnih stabala. Kodiranje stabla. Spoljašnja i unutrašnja stabilnost grafa. Pokrivanje i uparivanje. Logički permanent. Fundamentalni ciklusi i preseci. Bojenje grafa.", "RII", "Teorija grafova", "Druga", "TG" },
                    { 12, "Osnove HTML 5. Semantičko označavanje elemenata. Napredni koncepti CSS-a. Osnovni koncepti prilagodljivog (Responsive) Veb dizajna. Bogati Veb korisnički interfejsi i AJAX.  Arhitektura naprednih Veb aplikacija. Domenski vođeno projektovanje. Projektni obrasci u poslovnim Veb aplikacijama. MVC paradigma pri razvoju Veb aplikacija. Inverzija kontrole. Serijalizacija i prenos podataka, XML i JSON. Objektno-relaciono mapiranje. HTTP protokol. REST Veb servisi. Skalabilnost i postizanje visokih performansi Veb aplikacija.", "RII", "Razvoj Web aplikacija", "Treca", "RWA" },
                    { 13, "Ciljevi. Hardverski koncepti. Softverski koncepti. Klijent-server model. Primeri distribuiranih sistema. Komunikacije u DS.  Modeli Middleware. Pozivi udaljenih procedura. DCE.Pozivi udaljenih objekata. RMI. Komunikacija bazirana na porukama.  MPI. Načini imenovanja. Sinhronizacija. Sinhronizacija časovnika. Logički i fizički časovnik. Lamportove markice. Vektorski časovnici. Sinhronizacija međusobno uslovljenih događaja. Algoritmi izbora koordinatora. Uzajamno isključivanje. Distribuirane transakcije. Konzistentnost i replikacija. Modeli konzistencije. Protokoli. Otpornost na otkaze. Pouzdana klijent-server komunikacija. Pouzdana grupna komunikacija. Distribuirani fajl sistem. Sun network fajl sistem. P2P sistemi.", "RII", "Distribuirani sistemi", "Treca", "DS" },
                    { 14, "Uvod i opšti principi: Predmet i cilj izučavanja teorije igara. Kratki pregled istorije teorije igara. Osnovni pojmovi i definicije teorije igara. Terminologija. Klasifikacija igara. Strateško razmišljanje. Značaj i definicije pravila igre. Racionalnost i zajedničko znanje. Pojam ekvilibrijuma. Igre sa simultanim potezima (statičke igre).  Igre sa sekvencijalnim potezima (dinamičke igre). Koncept dominacije (forsiranja). Mešovite strategije i nepredvidivost. Nešov ekvilibrijum. Mešovite igre. Opšte klase igara i strategija: Kooperativne i nekooperativne igre. Karakteristične igre. Strateška upotreba informacija. Strateški i taktički potezi. Primene teorije igara: u informatici, u ekonomiji, političkim i vojnim naukama. Primena u kompjuterskim logičkim igrama. Ostale primene.", "RII", "Teorija igara", "Treca", "TIG" },
                    { 15, "Signali kao funkcije, nosioci informacija. Predstavljanje signala, diskretizacija i kvantovanje. Sistem kao automat. Frekventna dekompozicija signala. Teorija odabiranja  signala, Konvolucija, Furijeovi redovi i transformacije. Laplasova i  Z transformacija.", "RII", "Osnovi analize signala i sistema", "Treca", "OASIS" },
                    { 16, "Uvod u sisteme baza podataka: Kratak pregled relacionog modela podataka i relacionih upitnih jezika. Osnovni koncepti sistema baza podataka. Arhitekture sistema baze podataka. Moderni izazovi za Sisteme baza podataka. Napredne tehnike korišćenja SQLa: različiti tipovi spojeva kod SQLa, set i bag semantika (poređenje sa relacionom algebrom), rad sa datumima u SQLu, ugnježdeni upiti - korelisani i nekorelisani, klauzula CASE, IN i EXIST upiti, kvantifikovani upiti (ALL i ANY), grupisanje podataka i napredne tehnike grupisanja. Sistem za upravljanje bazama podataka: pregled arhitekture, osnovnih modula i funkcija, primeri ovih sistema. Zapamćene procedure, Trigeri: pojam, namena i korišćenje trigera, sintaksa naredbe za kreiranje trigera, tipovi trigera i granularnost, trigeri na nivou vrste i na nivou izraza, redosled izvršavanja trigera. Obrada i optimizacija upita: pojam optimizacije upita, statička i dinamička optimizacija, sistemski katalog, statistika baze podataka i optimizacija, indeksne strukture i višedimenzionalni indeksi. Sigurnost sistema baza podataka: pojam sigurnosti sistema baza podataka, sigurnost kod sistema za upravljanje bazama podataka (DBMS), privilegije korisnika – dodela i oduzimanje (GRANT i REVOKE naredbe), propagacija privilegija, sigurnost na nivou pogleda, statističke baze podataka, DAC i MAC mehanizam sigurnosti. Objektno-orijentisana paradigma i baze podataka: OO baze podataka, objekat kod OO baza i identitet objekta, OQL i SQL, objektno-relacione baze podataka, objektno-orijentisani i relacioni model podataka – razlike, prednosti i nedostaci, strukturni tipovi kod objektno-relacionih baza podataka, preslikavanje objektno-orijentisanog na relacioni model podataka.", "RII", "Sistemi baza podataka", "Treca", "SBP" },
                    { 17, "Pregled metoda i tehnika za OO projektovanje. Objektno orijentisano projektovanje korišćenjem UML objedinjenog jezika za modeliranje. Identifikacija elemenata projekta. Identifikacija projektnih mehanizama. Opis run-time arhitekture. Projektovanje Use-Case dijagrama. Projektovanje podsistema. Projektovanje klasa: struktura klasa, modeliranje stanja, relacije izmedju klasa. Projektni obrasci. Implementacioni model. Projektovanje komponenata. Distribuiranje aplikacije kroz Web servise. Prednost komponenata sa jednostavnijim klasama. Dekompozicija sistema po procesorima, zadacima i nitima. Preslikavanje projekta na konkurentni sistem. Primer OO projekta realnog sistema.", "RII", "Objektno-orijentisano projektovanje", "Treca", "OOP" },
                    { 18, "Uvod i pregled operativnih sistema. Upravljanje procesima. Niti i upravljanje nitima. Konkurentnost: uzajamno isključivanje i sinhronizacija.Uzajamno blokiranje i gladovanje procesa/niti. Upravljanje glavnom memorijom. Virtuelna memorija. Planiranje procesa i niti. Upravljanje U/I i raspoređivanje pristupa disku.Upravljanje datotekama. Korisnički interfejsi operativnih sistema. Razmatranje strukture i implementacije aktuelnih operativnih sistema.: UNIX/Linux, MS Windows, itd.", "RII", "Operativni sistemi", "Treca", "OS" },
                    { 19, "Uvod. Istorijat. Upotreba RM. Taksonomija RM. Referentni modeli. ISO/OSI referentni model. Protokoli i servisi. TCP/IP referentni model. Poređenje referentnih modela. Mrežni hardver i softver. Nivo veze za podatke. Kontrola grešaka i kontrola toka. Tehnike za detekciju grešaka. Protokoli sa klizajućim prozorom. Primeri protokola: HDLC, PPP. Lokalne mreže. Protokoli za emisione kanale. CSMA/CD. IEEE standard 802 za LAN.  Povezivanje mreže: ripiteri, habovi, mostovi, svičevi. Mrežni nivo. Virtuelni kanal. Datagram. Algoritmi za rutiranje. Određivanje najkraćeg puta. Dijkstrin algoritam. Bujica. “Distance vector” algoritam rutiranja. “Link state” algoritam rutiranja. Hijerarhijsko rutiranje. Kontrola zagušenja. Mrežni nivo u Internetu. IP protokol. IP adrese. Podmreže. NAT. Upravljački protokoli: ICMP, ARP, DHCP. RIP. Transportni nivo. Transportne usluge. Kvalitet usluga (QoS). Adresiranje. Portovi. Uspostavljanje veze. Multipleksiranje i demultipleksiranje. Internet transportni protokoli: TCP i UDP. Soketi i rad sa soketima.  Aplikativni nivo. Mrežne aplikacije i odgovarajući protokoli DNS, e-mail,  FTP, WWW, HTTP. Bezbednost mreže i kriptografija. Algoritmi sa tajnim ključem. DES. Algoritmi sa javnim ključem. Protokoli za autentifikaciju. Digitalni potpis.", "RII", "Računarske mreže", "Treca", "RM" },
                    { 20, "Web kao multimedijalni servis Interneta, HTTP protokol i HTML. Elementi HTML jezika. CSS-Definisanje i upotreba stilova. Programiranje klijenta (Elementi JavaScript jezika). Interaktivne Web aplikacije. Programiranje servera. (CGI, ASP, PHP). Višeslojne Web aplikacije. Osnovne Java tehnologije za Web  programiranje. Elementi XML-a  i njegova primena.  Preslikavanje XML-a u HTML Web servisi. AJAX tehnologija  i Web 2.0.", "RII", "Web programiranje", "Treca", "WP" },
                    { 21, "Uloga i značaj algoritama. Pojam efikasnosti i složenosti algoritma. Paradigme za generisanje algoritama (metod grube sile, iterativni algoritmi, rekurzivni algoritmi, eliminisanje rekurzije, razlaganje (divide-conquer), backtracking, dinamičko programiranje, linearno programiranje). Klasifikacija algoritama (algoritmi za sortiranje, algoritmi traženja, algoritmi za obradu stringova, algoritmi sa grafovima, geometrijski algoritmi, kriptografski algoritmi, algoritmi za kompresiju datoteka, aritmetički algoritmi, itd). Tehnike za izračunavanje složenosti. Kriterijumi i mere za ocenu složenosti algoritama. Osnove analize algoritama: najgori, srednji i najbolji slučaj; empirijsko merenje performansi algoritama. Pregled tehnika dokazivanja. Korišćenje verovatnoće u oceni složenosti algoritama.  Strukture podataka i složenost operacija za rad sa strukturama podataka. Izbor strukture podataka za implementaciju algoritama. Algoritmi za rad sa stringovima: LCS, Knut-Moris-Pratov algoritam, Bozer-Mooreov algoritam, Rabin-Karpov algoritam, primena konačnih automata. Aproksimativno poklapanje. Sufiksna stabla i sufiksni nizovi. Dinamičko programiranje. Gridi algoritmi. FFT i FFT slični algoritmi. NP problemi. SAT.", "RII", "Projektovanje i analiza algoritama", "Treca", "PAA" },
                    { 22, "Arhitekture mikroračunarskih sistema. Magistrale mikroračunarskih sistema. Arhitektura mikroprocesora. Programski modeli 16-bitnih i 32-bitnih mikroprocesora. RISC procesori. Načini organizacije ulaza/izlaza. Programirani ulaz/izlaz. Sistem prekida. Direktan pristup memoriji (DMA). Paralelni U/I. Serijski U/I. Standardni serijski interfejsi (RS 232c, RS 485). Mikroračunar na čipu. Mikrokontroleri. Embeded procesiranje, karakteristike embeded računara.", "RII", "Mikroračunarski sistemi", "Treca", "MIKS" },
                    { 23, "Uvod (Kratak pregled primene informacionih sistema, Informatika, Informacione tehnologije, Računarstvo). Osnovni koncepti informacionih sistema (Informacione i komunikacione tehnologije kao tehnološka osnova informacionih sistema. Organizacioni aspekti informacionih sistema. Tehnološki aspekti informacionih sistema.) Metodi analize i projektovanja informacionih sistema (Analiza ivodljivosti i predlog sistemskog rešenja. Modeliranje i analiza sistema. Projektovanje sistema. Realizacija sistema.) Oblasti primene informacionih sistema za slučaj rešenja sa dostupnim izvornim kodom (Open Source). (DMS – Informacioni sistemi za upravljanje i rad sa dokumentima, CMS – Informacioni sistemi za menadžment sadržaja, JMS – Java Messaging Service kao primer komunikacione infrastrukture informacionih sistema, Informacioni sistemi na nivou strategije, DSS – Informacioni sistemi za podršku odlučivanju, Informacioni sistemi za podršku rada sa velikim brojem korisnika – Customer Management Systems, Informacioni sistemi za upravljanje znanjem, Kolaborativni informacioni sistemi.)", "RII", "Informacioni sistemi", "Treca", "IS" },
                    { 24, "Pojam i potreba za softverskim inženjerstvom. Modeli razvoja softvera. Softverski procesi. Agilni razvoj softvera. Osnovne aktivnosti u upravljanju softverskim projektima. Metode inženjeringa zahteva. Arhitekture softvera. Projektovanje softvera. Principi realizacije softvera. Validacija i verifikacija. Sistematsko testiranje softvera. Softverske metrike. Održavanje i evolucija softvera.", "RII", "Softversko inženjerstvo", "Treca", "SI" },
                    { 25, "Osnovni pojmovi i istorijski pregled oblasti. Ciljevi interakcije čovek-računar i odnos sa aplikacijama interaktivnog računarskog sistema. Psihološki aspekti. Mentalni modeli i projektovanje interfejsa. Uređaji za interakciju čovek-računar. Paradigme interakcije. Analiza, projektovanje i evaluacija interfejsa čovek-računar. Životni ciklus softvera i interakcija čovek-računar. Standardi i vodiči za realizaciju korisničkog interfejsa. Alati za razvoj korisničkog interfejsa. Nove paradigme za interakciju: sveprisutno računarstvo, virtuelna realnost, proširena realnost, multimodalni interfejsi, hipertekst.", "RII", "Interakcija čovek-računar", "Treca", "INT" },
                    { 26, "Matematička osnova logičkih igara. Matematički modeli logičkih igara - primeri. Opšte klase logičkih igara. Karakteristične logičke igre. Osnove algoritama logičkih igara. Pojam kompleksnosti i kombinatorne eksplozije. Metode za prevazilaženje problema kompleksnosti. Metoda heurističkog sečenja stabla odlučivanja (forward pruning). Ograničavanje ekspanzije stabla. Osnovni algoritmi za obradu stabla u logičkim igrama. Alfa-Beta,PVS,Null-move,NegaScout,MTD(f),Probe i Multu-Cut ,Quiescence,MVV-LVA i SEE procedure. Pomoćne procedure i heuristike (Minimal Window Search, ETC, History,Futility,Contempt factor). Alternativni algoritmi logičkih igara - Berlinerov algoritam. Paralelni algoritmi logičkih igara. Primena transpozicionih baza u logičkim igrama. Evaluacione funkcije. Paralelni i distribuirani algoritmi logičkih igara. Client-Server arhitektura kao osnova implementacije logičkih igara na internetu. Primeri i analiza instaliranih velikih sistema za daljinsko igranje logičkih igara (facebook games, playchess server).", "RII", "Algoritmi logičkih igara", "Cetvrta", "ALI" },
                    { 27, "Uvod u servisno-orijentisano računarstvo (SOC) i servisno-orijentisanu arhitekturu (SOA). Osnovni principi servisno-orijentisanog računarstva: komunikacija, koordinacija, stanje, sigurnost. Analiza i projektovanje sistema servisno-orijentisane arhitekture. Servisno-orijentisana arhitektura i Web servisi. Osnovne tehnologije Web servisa (SOAP, WSDL i UDDI). REST principi i RESTful Web servisi. Kompozicija, koordinacija i orkestracija servisa. Integracija aplikacija i sistema na nivou organizacije i Enterpise Service Bus (ESB) tehnologije. Sigurnost u servisno-orijentisanoj arhitekturi. Implementacija SOA na razvojnim platformama JavaEE i .NET. Standardi i specifikacije Web servisa. Servisne platforme (OSGi).Servisno-orijentisano računarstvo i računarstvo u oblaku.", "RII", "Servisno-orijentisane arhitekture", "Cetvrta", "SOA" },
                    { 29, "Diskretni signali u vremenskom i frekventnom području. Diskretna furieova transformacija (DFT) i Brza Furieova transformacija (FFT), z- transformacija i uopštenja. Kosinusna transformacija. Smplovanje (odabiranje) i rekonstrukcija signala.Diskretni sistemi u vremenskom i frekventnom području. Brza konvolucija. Višerezolucijaska (Multi-rate) obrada signala. Spektralna analiza i kratka kratka (short time) Furijeova transformacija. Projektovanje filtara. Efekti kvantizacije.", "RII", "Metodi i sistemi za obradu signala", "Cetvrta", "MSOS" },
                    { 60, "Ovladavanje naprednim metodama za razvoj i evoluciju softvera i metodama za merenje kvaliteta softverskih proizvoda i procesa.Sadržaj", "RII", "Napredno softversko inženjerstvo", "Master", "NSI" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ccc36cd-2423-418d-b13c-dab0272fef0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37278f11-1b01-4a26-801b-bae64fb471dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81fd2fec-b17a-4c72-8686-25f5d77e0909");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df2f4ded-1acd-47d9-b75b-218a19062fc6");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5569518-fe56-4631-a66d-bd1b01b4ceda", "826cc343-fc58-4294-a378-43e14d0c5f98", "Admin", "ADMIN" },
                    { "9a9319eb-9060-4624-978f-9efedcf9dfb8", "83ed0043-e378-4d1b-9203-35feb584b46e", "Moderator", "MODERATOR" },
                    { "33218622-37d8-4f3e-8ac0-bd34b4acfa0f", "a44c8e9c-9d89-4fa9-bcf8-6308b8c4eaac", "Student", "STUDENT" },
                    { "8faf6aa6-8c29-460e-8882-37bfcc693147", "27569c96-afde-4663-9a5e-29fb829c5f4c", "Profesor", "PROFESOR" }
                });
        }
    }
}

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
                    { 42, "Na kraju kursa student ce biti u stanju da razume osnovne probleme, moguca resenja i pravce istraZivanja u vestackoj inteligenciji. Student ce biti u stanju da odgovori na pitanja: sta je vestacka inteligencija, od cega se sastoje ekspertni sistemi, sta je inZenjerstvo znanja i koji se formalizmi koriste za predstavljanje znanja. Student ce biti osposobljen da prepozna probleme vestacke inteligencije i nacine njihovog resavanja preko algoritama iz razlicitih oblasti vestacke inteligencije koje je savladao. Student ce biti osposebljen da razvije programe bazirane na tehnikama vestacke inteligencije u Lisp-u i drugim programskim jezicima.", "RII", "Vestacka inteligencija", "Cetvrta", "VI" },
                    { 41, "Model podataka za Skladista podataka. Koncepti, algoritmi, tehnike i sistemi za skladistenje podataka i otkrivanje znanja. Arhitekture skladista podataka. Implementacija skladista podataka: ekstrakcija podataka, preciscavanje, transformacija, data cube i ucitavanje. OLAP obrada upita. Proces otkrivanja znanja. Arhitektura sistema za otkrivanje znanja. Veza sistema za otkrivanje znanja sa skladistima podataka i OLAP sistemima. Prethodna obrada podataka. Tehnike otkrivanja znanja. Upitni jezik za otkrivanje znanja. Klasifikacija i predikcija. Analiza klastera. Otkrivanje znanja kod kompleksnih tipova podataka (iz prostornih i multimedijalnih baza podataka). Aplikacije za otkrivanje znanja i trendovi razvoja - otkrivanje znanja u tekstu, na Vebu, pretraZivanje Veba, rang stranica, Veb spam.", "RII", "Skladistenje podataka i otkrivanje znanja", "Cetvrta", "SPOZ" },
                    { 40, "Proces i tok projektovanja. OkruZenja za simulaciju i sintezu. Verifikacija kola. Projektovanje aritmetickih kola. VHDL opisi osnovnih digitalnh kola u VHDL-u. Kompromisi u projektovanju. Projektovanje sloZenijih racunarskih komponenti. VHDL opis i sinteza. Model toka podataka.  Izracunavanja vodjena podacima. Projektovanje i implementacija procesora baziranih na toku podataka u Java okruZenju. Projektovanje procesne jedinice. Projektovanje upravljackih modula. Projektovanje memorijskog sistema. Projektovanje sistema magistrala. Projektovanje ulazno-izlaznog podsistema. Upravljanje potrosnjom kola. Projektovanje procesora posebne namene.", "RII", "Projektovanje racunarskog hardvera", "Cetvrta", "PRH" },
                    { 39, "Potrebe za paralelnim racunarskim sistemima (PRS).Klasifikacija PRS. Performanse racunarskih sistema.  Ubrzanje. Amdalov zakon. Efikasnost. Efektivni paralelni algoritmi. Princip neogranicenog paralellizma. Stepen paralelizma. Granularnost programa. Zavisnosti u programu. Zavisnosti po podacima. Prave zavisnosti. Antizavisnosti. Izlazne zavisnosti. Eliminacija zavisnosti. Kontrolne zavisnosti. Vektorski racunari. Arhitekture. Vektorizacija petlji. Procesorska polja.  Maskiranje procesnih elemenata. Paralelizacija ugnjeZdjenih petlji. Primeri SIMD algoritama. SpreZne mreZe (SM). Staticke SM. Dinamicke SM: jednostepene i visestepene.Rutiranje. Muliprocesori i multiracunari.  ArbitraZa na magistrali. Kes koherencija. Hardverski protokoli kes koherencije: njuskala (Snoopy) i direktorijumske seme. Komunikacija i sinhronizacija procesa u MIMD sistemima: semafori, monitori, tehnika slanja poruka. Primeri algoritama za MIMD sisteme. Multiprocesori na cipu.", "RII", "Paralelni sistemi", "Cetvrta", "PS" },
                    { 38, "Savremene platforme za podrsku ucenju; istorija tehnologija za podrsku ucenju i pojam ucenja podrZanog tehnologijom. E-ucenje, m-ucenje, e-testiranje i personalizovano ucenje i testiranje. Pristupi ucenju i vrste tehnoloske podrske ucenju. Hardverska i softverska infrastruktura platformi za podrsku ucenju. Sistemi za organizaciju ucenja (LMS); virtuelna okruZenja za ucenje (VLE); multimedijalne i multimodalne komponente za ucenje; inteligentni tutorski sistemi.", "RII", "Tehnologije za podrsku ucenju", "Cetvrta", "TPU" },
                    { 36, "Elementi kriptologije, kriptografije i kriptoanalize. Autorizovani pristup. Metode identifikacije. Razvoj sistema sa autorizovanim pristupom. Simetricna kriptografija. Javni i tajni kljuc. Hash funkcije. Metoda napada na zasticeni sistem. Sertifikati, odrZavanje i izdavanje sertifikata. Osnovni sigurnosni protokoli. Tipovi malware programa.", "RII", "Zastita informacija", "Cetvrta", "ZI" },
                    { 43, "Uvod u mobilne sisteme i servise. Mobilni racunarsko/komunikacioni uredjaji, pametni telefoni, tableti. BeZicne mreZe i protokoli. Operativni sistemi, middleware platforme i programska okruZenja za razvoj mobilnih aplikacija i servisa. Arhitektura i projektovanje mobilnih aplikacija i servisa. Mobilne Web aplikacije i Mobile 2.0. Korisnicki interfejsi mobilnih aplikacija i servisa. Upravljanje podacima u mobilnim aplikacijama i mobilne baze podataka. Mobilna sigurnost. Mobilna razmena poruka. Mobilno pozicioniranje. Lokaciono-zasnovani i kontekstno-svesni servisi. Savremene aplikacije: mobilno poslovanje, inteligentni transportni sistemi, turisticki vodici, mobilna zdravstvena zastita, mobilne igre, upravljanje vanrednim situacijama, itd.", "RII", "Mobilni sistemi i servisi", "Cetvrta", "MSS" },
                    { 35, "Formalni jezici i gramatike, Automati kao uredjaji za prepoznavanje jezika. Leksicki analizator. Sintaksna analiza. LLk gramatike i analizatori. Operatorske ramatike. LR analizatori. Generatori analizatora (Lex i Yacc). Medjukodovi. Lokalna optimizacija koda. Analiza na nivou tipova podataka. Oprimizacija koda. Staticka i dinamicka raspodela memorije. Interpretatori. Asembler i makroasembler.", "RII", "Programski prevodioci", "Cetvrta", "PP" },
                    { 34, "Uvod u interaktivnu racunarsku grafiku i sisteme za racunarsku grafiku. Hardver za racunarsku grafiku. Rasterski graficki algoritmi za crtanje, ispunu i isecanje 2D primitiva (linija, krug elipsa). 2D i 3D geometrijske transformacije. Komponovanje transformacija. Algoritmi za ostvarivanje realnosti prikaza. Modeli boja. Svetlo i modeli osvetljenja. Modeli sencenja. Algoritmi za generisanje senki. Modeliranje krivih i povrsi (Splajn, Bezierove i NURBS krive i povrsi). Alati i softver za racunarsku grafiku. Graficki API (GDI, GDI+, OpenGL). Interaktivno graficko programiranje.", "RII", "Racunarska grafika", "Cetvrta", "RG" },
                    { 33, "Uvodne teme: tradicionalne relacione baze podataka, transakcije, ACID svojstva, oporavak i kontrola konkurencije. Distribuirane baze podataka, moderni trendovi i problemi, skalabilnost i problemi realizacije ACID svojstava kod takvih sistema. Interoperabilnost i integracija informacija. Medijatori, Skladista podataka, Federativne baze podataka. Objektne i objektno-relacione baze podataka - pojam, osnovni koncepti Baze podataka u Web okruZenju. Semanticki Web i baze podataka – pojam, osnovni koncepti, ontologije. XML i baze podataka. Relacione baze podataka i XML. Native XML baze podataka. NoSQL baze podataka: pojam, osnovni koncepti.", "RII", "Napredne baze podataka", "Cetvrta", "NBP" },
                    { 32, "Uvod u arhitekturu i projektovanje softvera. Osnovni principi i metode projektovanja softvera. Projektovanje softvera primenom projektnih obrazaca. Refaktoring projektovanja u projektne obrasce. Arhitektura softvera - osnovni principi i metode. Modularnost softverskog sistema. Sprega, kohezija, interfejsi i konektori softverskih komponenti. Arhitekturni stilovi i obrasci. Razvoj i dokumentovanje arhitekture softvera. Softverske komponente, aplikacioni okviri i middleware platforme. Arhitektura enterprise aplikacija. Servisno-orijentisana arhitektura i Web servisi. Modelom vodjena arhitektura (Model Driven Architecture - MDA) i razvoj softvera.", "RII", "Arhitektura i projektovanje softvera", "Cetvrta", "AIPS" },
                    { 37, "Uvod i pregled oblasti. Mediji. Zahtevi multimedijalnog procesiranja. MreZe za multimediju i protokoli za striming informacija. Formati za zvuk, tekst, mirnu i pokretnu sliku. Metode za kompresiju slike, audio i video signala. Potpuni MPEG-4 standard za multimediju. Drugi MPEG standardi. Zastita multimedijalnih sadrZaja i metode za wathermarking. Vrste multimedijalnih sistema i primene (npr. videokonferencije, ucenje na zahtev, itd.). Arhitekture multimedijalnih sistema. Performanse multimedijalnih sistema. Mobilni multimedijalni sistemi. Perspektive razvoja multimedijalnih sistema.", "RII", "Multimedijalni sistemi", "Cetvrta", "MS" },
                    { 44, "Cilj predmeta je upoznavanje studenata sa naprednim distribuiranim algoritmima i strukturama podataka, koje omogucavaju razumevanje koncepta blokcein sistema, kao i sa naprednim tehnologijama koje omogucavaju implementaciju ovih sistema.Ocekuje se da student stekne potrebno znanje za razumevanje principa i koncepata vezanih za blokcein tehnologiju, kao i da moZe da primeni dostupne alate i okruZenja, i implementira privatne i javne blokcein sisteme samostalno ili u dostupnim okruZenjima. Ocekuje se da student ovlada tehnologijama kako bi mogao da samostalno razvije distribuirane aplikacije na Ethereum blokcein platformi.Osnovni koncepti blokceina. Decentralizacija. Komunikacija kod decentralizovanih sistema. Elementi kriptografije, kriptografske primitive. Sistemi sa javnim kljucem, PKI, RSA, ECC. Hes funkcije, SHA-1, SHA-2, MD5. Upotreba OpenSSL. Otpornost na greske i konsenzus algoritmi. Kriptovalute i kriptoekonomija. Javni i privatni blokcein sistemi. Bitkoin. Digitalni kljucevi i adrese. Transakcije. Rudarenje, CPU, GPU, FPGA, ASIC. Alternativne valute. Ethereum. Pametni ugovori. Programiranje u Ethereum-u. Imllementacija Ethereum sistema. Razvojni alati. Hyperlegder. Primena blokcein sistema.", "RII", "Blokchain tehnologije", "Master", "BT" },
                    { 46, "Sticanje znanja o tehnikama za obradu slike i osposobljavanje studenta za samostalnu primenu naucenih tehnika za resavanje realnih problema", "RII", "Napredne tehnike za obradu slike", "Master", "NTOS" },
                    { 31, "Osnovni koncepti umreZavanja. Komutacija na nivoima 2 i 3. Karakteristike pasivne i aktivne mreZne opreme. MreZni modeli, hijerarhijski model projektovanja mreZa. Planiranje osnovnih servisa, planiranje distribuiranih servisa, planiranje lokalnih servisa, planiranje pouzdanosti mreZe. Zahtevi, identifikacija i validacija. Dizajn mreZa. Logicki dizajn, fizicki dizajn, testiranje, optimizacija i dokumentacija mreZe. Proces projektovanja i implementacije mreZe. Tipicni modeli za implementaciju malih i srednjih mreZa. Virtualne mreZe. Trankovi. ISL i IEEE802.1 protokoli i enkapsulacija. VTP. Redundantne topologije. Protokoli za implementaciju redundantnih topologija na drugom nivou OSI modela. STP i Rapid STPprotokoli. Rutiranje izmedju virtualnih mreZa. Virtualni interfejsi. Osnovni koncepti internet telefonije. BeZicne mreZe, standardi, principi projektovanja, roming servis za mobilne uredjaje. Bezbednost mreZa. Tipicni scenariji napada. Osnovni koncepti za povecanje bezbednosti mreZa.", "RII", "Projektovanje racunarskih mreZa", "Cetvrta", "PRM" },
                    { 47, "Uvodjenje studenata u oblast virtuelne i prosirene realnosti i upoznavanje sa osnovnih uredjajima, algoritmima i tehnikama koje se koriste kod realizacije ovih sistem", "RII", "Sistemi virtuelne i prosirene realnosti", "Master", "SVPV" },
                    { 48, "Upoznavanje sa pojmom medicinske informatike i oblastima i nacinima primene informatike u medicini", "RII", "Medicinska informatika", "Master", "MI" },
                    { 49, "Pristupi masinskog ucenja: induktivno ucenje, analiticko ucenje. Izbor primera za sticanje iskustva, izbor i predstavljanje ciljne funkcije. Ucenje kao pretraZivanje i algoritmi za pretraZivanje prostora potencijanih hipoteza. Generisanje stabla odlucivanja. Ucenje zasnovano na instancama (case-based). Fazi logika. Vestacke neuronske mreZe. Arhitekture vestackih neuronskih mreZa, aktivacione funkcije, algoritmi ucenja, neuronske mreZe sa direktnim prostiranjem signala, rekurentne neuronske mreZe. Fazi neuronske mreZe. Evoluciono racunarstvo. Evoluciono programiranje, evolucione strategije, genetsko programiranje, genetski algoritmi i optimizacije, operatori genetskih algoritama, integracija genetskih algoritama i neuronskih mreZa.", "RII", "Soft kompjuting", "Master", "SK" },
                    { 50, "Upoznavanje sa arhitekturom 3D grafickih protocnih sistema, njihovim programibilnim stepenima i nacinom njihovog programiranja", "RII", "3D graficki protocni sistemi", "Master", "3D" },
                    { 51, "Razumevanje koncepata i tehnologija racunarstva visokih performansi kao i sticanje teorijskih i prakticnih znanja koja omogucavaju razvoj i analizu aplikacija visokih performansi na savremenim  racunarskim arhitekturama. ", "RII", "Racunarstvo visokih performansi", "Master", "RVP" },
                    { 52, "Cilj predmeta je da studenti steknu uvid u potencijalne bezbedonosne slabosti mreZa i dobiju osnovna znanja za povecanje bezbednosti, kao i potrebna aplikativna znanja i vestine koje mogu primeniti u cilju povecanja bezbednosti racunarskih mreZa", "RII", "Bezbednost racunarskih mreZa", "Master", "BRM" },
                    { 53, "forenzikuUpoznavanje sa procesom identifikacije, ocuvanja i analize digitalnih dokaza, kao i njihovu pripremu za prezentaciju na sudu u odgovarajucem postupku na forenzicki ispravan nacin.", "RII", "Digitalna forenzika", "Master", "DF" },
                    { 54, "Cilj predmeta je da studenti steknu znanja o o projektovanju embeded sistema.", "RII", "Embeded sistemi", "Master", "ES" },
                    { 55, "Na kraju kursa student ce biti u stanju da razume aktuelne probleme implementacije inteligentnih sistema, kao i buduce pravce istraZivanja i razvoja u vestackoj inteligenciji. Student ce biti u stanju da odgovori na izazove oko izbora i projektovanja pojednih delova inteligentnog sistema. Student ce biti osposobljen da prepozna probleme realizacije distribuiranih inteligentnih sistema, problem semanticke integracije informacija, i da implementira neka resenja zasnovana na ontologijama.", "RII", "Inteligentni sistemi", "Master", "IS" },
                    { 56, "Teorijska i prakticna znanja o konceptima, nacinima resavanja, projektovanju i implementaciji osnovnih elemenata interoperabilnosti sistema i integracije informacija.", "RII", "Interoperabilnost i integracija informacija", "Master", "III" },
                    { 57, "Uvodjenje studenata u oblast inZenjerstva zahteva i upoznavanje sa principima upravljanja zahtevima kao i sa osnovnim modelima inZenjerstva zahteva.", "RII", "InZenjerstvo zahteva", "Master", "IZ" },
                    { 58, "Sticanje znanja o XML i Web servisima za potrebe samostalnog razvoja Web 2.0 zasnovanih aplikacija", "RII", "Napredne Web tehnologije", "Master", "NWT" },
                    { 45, "Cilj ovog predmeta je da upozna studente sa specificnostima razvoja medicinskih informacionih sistema, kao i sa razlicitim kategorijama medicinskog softvera i pratecom zakonskom regulativom i standardima. Takodje, ovaj predmet treba da pruZi studentima i uvid u ceo proces razvoja kroz prakticne veZbe i razvoj samostalnog softverskog projekta", "RII", "Medicinski informacioni sistemi", "Master", "MIS" },
                    { 30, "InZenjerska etika (IEEE Eticki kod). Domaca i medjunarodna pravna regulativa. Autorska prava. Patenti. Zastita proizvoda. Licenciranje proizvoda. Tehnike zastitte. Garancija. Ugovaranje. Procedure javnih nabavki. Informaticki kriminal. Racunarsko vestacenje.", "RII", "Socijalni i pravni aspekti informatike", "Cetvrta", "SPAI" },
                    { 28, "Uvod i istorijat oblasti racunarskog vida. Operacije nad slikama. Racunanje i upotreba histograma. Binarizacija i segmentacija slika. Morfoloske operacije. Filtriranja slika. Detekcija ivica i uglova. Detekcija kontura i linija. Detekcija krugova i elipsi. Detektovanje i uparivanje karakteristicnih tacaka. Transformacija slika. Kalibracija kamere (korekcija radijalne distorzije). Procena projekcionih relacija izmedju para slika. Obrada video sekvenci (detekcija pokreta, identifikacija i pracenje objekata). Metode za rekonstrukciju trodimenzionalnih scena.", "RII", "Racunarski vid", "Cetvrta", "RV" },
                    { 59, "Razumevanje tehnologija, pravaca razvoja, kao i dizajna i implementacije savremenih operativnih sistema i sistemskog softvera", "RII", "Napredni operativni sistemi", "Master", "NOS" },
                    { 1, "Brojni sistemi i predstavljanje podataka u racunaru. Bool-ova algebra. Prekidacke funkcije. Kombinacione prekidacke mreZe. Analiza i sinteza kombinacionih prekidackih mreZa. Standardni kombinacioni moduli. Sekvencijalne prekidacke mreZe. Standardni sekvencijalni moduli. Arhitektura racunara. Organizacija centralnog procesora i elementi asemblerskog jezika. Ulazno-izlazni uredjaji. Softver racunara - sisremski i aplikativni softver, razvoj softvera. Racunarske mreZe, Internet i Veb.", "RII", "Uvod u racunarstvo", "Prva", "UUR" },
                    { 2, "Algoritmi, osnovni pojmovi i nacin predstavljanja algoritma. Graficko predstavljanje algoritama. Upravljacke strukture. UgnjeZdene upravljacke strukture. Tipovi i strukture podataka. Osnovni tipovi podataka. Strukturni tipovi podataka: linearni, nelinearni. Primeri algoritama. Programski jezik C. Faze u razvoju C programa. Azbuka C-a i struktura programa. Tipovi podataka u C-u. Konstante. Operatori. Prioritet operatora. Struktura C programa i f-ja main. Standardni ulaz i izlaz. Kontrola toka programa. Nizovi i matrice. Dekompozicija i funkcije u C-u. Prenos parametara. Parametri funkcije main. Rekurzivne funkcije. Standardna biblioteka C funkcija. Izvedeni tipovi podataka: pokazivaci, strukture, ugneZdene strukture, samoreferencirajuce strukture, unije. Dinamicka alokacija memorije. Preprocesorske direktive. Memorijske klase identifikatora. Stringovi. Nizovi pokazivaca, matrica stringova. Ulaz, izlaz i rad sa fajlovima. Tekstualni i binarni fajlovi.", "RII", "Algoritmi i programiranje", "Prva", "AIP" },
                    { 3, "Matematicka logika. Iskazni racun. Iskazne formule. Koegzistencija i logicke posledice.Minimizacija zagrada i logickih veznika. Normalne forme. Skupovi. Predstavljanje.Operacije sa skupovima. Princip sume. Princip ukljucenja-iskljucenja. partitivni skup. Razbijanje skupa.Dekartov proizvod. Princip proizvoda. Relacije. Matricno predstavljanje. Zatvaranje relacija. relacija poretka i ekvivalencije.Leksikografsko uredjenje. Funkcije. Principi injekcije, sirjekcije, bijekcije, komplementa. Dirihleov princip. Nizovi. Funkcije generatrise.Rekurentni nizovi. Resavanje linearnih rekurentnih relacija. Fibonacijevi, Katalanovi i Stirlingovi brojevi. Konacne razlike i sume. Permanent.Izracunavanje i osobine. Permanent matrica u specijalnom obliku. Sistemi razlicitih predstavnika. Celi brojevi. Deljivost. NZS i NZD. Euklidov algoritam.Diofantove jednacine. Modularne jednacine. Kineska teorema o ostacima. Ojlerova funkcija. Mala Fermaova teorema. VeriZni razlomci. Modularna aritmetika.", "RII", "Diskretna matematika", "Druga", "DM" },
                    { 4, "Pregled osnovnih komponenti racunarskih sistema. Organizacija racunarskog sistema. Procesor. Memorijski podsistem. Magistrale. Ulazno/izlazni (U/I) podsistem. Struktura procesora i njegove funkcije. Registarski skup. Pribavljanje i izvrsenje instrukcija. Aritmeticko-logicka jedinica (realizacije racunarskih operacija). Predstavljanje numerickih podataka. Predstavljanje nenumerickih podataka. Sistem prekida. Programski model mikroprocesora. Makro naredbe. Procedure. Potprogrami i prenos parametara. Prekidni programi. Organizacija ulaza/izlaza. Paralelni i serijski U/I. U/I uredjaji. Programirani U/I. U/I upravljan prekidima. U/I direktnim pristupom memoriji.", "RII", "Racunarski sistemi", "Druga", "RS" },
                    { 5, "Pregled tehnika programiranja. Modelovanje problema. Klase. Objekti. Modelovanje problema klasama. Definisanje klase. Pristup clanovima klase. Scope. Razdvajanje interfejsa od implementacije. Inline funkcije. Konstruktori. Destruktori. Redosled poziva konstruktora i destruktora. Copy konstruktori. Prijatelji klasa. Prijateljske funkcije. Prijateljske klase. Preklapanje operatora. Operatorske funkcije. Bocni efekti i veze izmedju operatorskih funkcija. Izbor povratnih vrednosti operatorskih funkcija. Izvodjenje, nasledjivanje, specijalizacija, generalizacija. Definisanje izvedene klase. Vidljivost i prava pristupa. Nacini izvodjenja. Konstruktori i destruktori izvedenih klasa. Konverzija pokazivaca i referenci. Polimorfizam. Virtuelne funkcije. ciste virtuelne funkcije. Apstraktne klase. Virtuelni destruktor.  Nizovi i izvedene klase. Visestruko nasledjivanje. Konstruktori i destruktori kod visestrukog nasledjivanja. Visestruki podobjekti. Virtuelne osnovne klase. Genericki mehanizam-sabloni.  Generisanje funkcija. Generisanje klasa. Obrada izuzetaka. Izazivanje izuzetaka. Prihvatanje izuzetaka. Neprihvaceni izuzeci. Ulazno-izlazni tokovi. Standardni tokovi. Klase za ulazen tokove. Konstruisanje objekata ulaznih tokova. Operacije ulaznog toka. Preklapanje operatroa ekstrakcije. Izlazni tokovi. Upotreba operatora umetanja. Formatiranje izlaza. Operacije izlaznog toka. Preklapanje operatora umetanja za korisnicke tipove. Standardna biblioteka. Namespace. Kontejnerske klase (vektori, liste, stekovi, redovi, mape, skupovi, ...). Klase: Iteratori, Algoritmi. String.", "RII", "Objektno orijentisano programiranje", "Druga", "OOP" },
                    { 6, "Osnove prekidacke teorije. Algebarske strukture za logicko projektovanje. Predstavljanje diskretnih funkcija, klasicni pristupi, funkcionalni razvoji, dijagrami odlucivanja. Klasifikacija prekidackih funkcija. Klasicni pristupi realizaciji prekidackih funkcija. Multiplekserska sinteza. Realizacija prekidackih funkcija programabilnim kolima, PLA, realizacija primenom ROM-a, FPGA. Bulova diferenca i primene u otkrivanju gresaka. Lako testabilne realizacije. Sekvencijalne mreZe, kodiranje i optimizacija. Realizacija sekvencijalnih mreZa.", "RII", "Logicko projektovanje", "Druga", "LP" },
                    { 7, "Implementacija procesora: putevi podataka procesora i upravljacka jedinica. Hardverska i mikroprogramska realizacija upravljacke jedinice. Protocno izvrsavanje instrukcija. Strukturni hazardi. Hazardi podataka. Hazardi upravljanja. Izbegavanje hazarda podataka premoscavanjem. Izbegavanje hazarda podataka planiranjem instrukcija. Smanjenje cene grananja. Prosirenje protocnog sistema za rukovanje operacijama sa vise ciklusa. Superskalarni procesori. VLIW procesori. Izvrsavanje aritmetickih operacija. Tehnike za ubrzanje celobrojnog sabiranja, mnoZenja i deljenja. Operacije sa podacima sa pokretnom zapetom. Protocna organizacija aritmeticke jedinice. Elementi memorijskog sistema. Hijerarhijska organizacija memorijskog sistema. Kes memorija procesora. Glavna memorija. Kes memorija diskova. Virtuelna memorija.", "RII", "Arhitektura i organizacija racunara", "Druga", "AOR" },
                    { 8, "Razvoj programskih jezika. Uloga programskih prevodioca.  Formalni opis jezika. Elementi jezika. Sistem tipova podataka.  Strukturni tipovi podataka. Dinamicki tipovi podataka. Osnovne upravljacke strukture. Potprogrami i moduli. Apstrakcija. Objektno orijentisani jezici, Jezici za konkurentno programiranje. Obrada izuzetaka. Mehanizmi niskog nivoa. Integrisana razvojna okruZenja. Funkcionalni jezici. Jezici za Veb programiranje.", "RII", "Programski jezici", "Druga", "PJ" },
                    { 9, "Definicija i pregled struktura podataka, strukture podataka u sofverskom inZenjerstvu, kategorizacija struktura podataka, pseudokod, sloZenost i ocena sloZenosti algoritama. Nizovi: difinicija nizova, operacije sa nizovima, tipovi podataka string. Lancane liste: definicija strukture, tipovi lancanih listi - jednostruko povezane, dvostruko povezane, ciklicne, osnovne operacije (obilazak, dodavanje, brisanje), napredne operacije, staticka i dinamicka implementacija lancanih listi. Red, Magacin, Dek: definicija strukture, staticka i dinamicka implementacija reda, magacina i deka, osnovne operacije (obilazak, dodavanje, brisanje) kod staticke i dinamicke implementacije. Hes tablice: definicija strukture, definicija pojmova (hes funkcija, kolizija i sinonimi), resavanje kolizije (otvoreno adresiranje, ulancavanje sinonima), implementacija hes tablice, osnovne operacije (traZenje, citanje/brisanje). Stabla: osnovni pojmovi, binarna i opsta stabla, operacije (obilazak, dodavanje i brisanje cvorova), uredjena binarna stabla, staticka i dinamicka implementacija stabla, Heap (gomila) – nacin formiranja, primena (sortiranje), stabla traZenja, B, B*, B++ stabla. Grafovi: definicije pojmova, staticka (matrice susedstva, matrice incidencije) i dinamicka reprezentacija grafa (lancane strukture), operacije za staicku i dinamicku implementaciju, obilazak grafa po sirini i po dubini, najkraci put u grafu za staticku i dinamicku reprezentaciju. Datoteke: sekvencijalne, direktne, indeks-sekvencijalne, indeks-nesekvencijalne, datoteke sa vise knjuceva. Rasuto adresiranje.", "RII", "Strukture podataka", "Druga", "SP" },
                    { 10, "Uvod u baze podataka: osnovni pojmovi (podatak, informacija, baza podataka, sistem za upravljanje bazama podataka, sistem baza podataka, aplikacije nad bazom podataka), konvencionalna obrada i obrada zasnovana na bazama podataka, kategorizacija korisnika baza podataka, prednosti i nedostaci, istorijat razvoja. Modeli podataka: nivoi apstrakcije kod DBMSa, pojam modela podataka i njegove komponente, koncpetualno projektovanje baze podataka, (E)ER model podataka, kocepti (E)ER modela i graficka notacija ((E)ER dijagram), projektovanje baze podataka koriscenjem (E)ER modela podataka. Relacioni model: koncepti relacionog modela, strukturna i integritetna komponenta, sema relacije, pojava relacije, kljuc relacije, specifikacija ogranicenja, SQL DDL naredbe. Relaciona algebra: relaciona algebra, operacije relacione algebre – selekcija, projekcija, spoj i vrste spojeva, unija, presek, razlika, Dekartov proizvod, upiti relacione algebre, primeri upita. Funkcionalne zavisnosti: definicija funkcionalni zavisnosti, pravila izvodjenja funkcionalni zavisnosti, zatvarac skupa funkcionalnih zavisnosti, zatvarac skupa atributa, odredjivanje jednog kljuca seme relacije, nalaZenje svih kljuceva. Analiza seme relacije: proces nalize i kvalitet projektovane seme baze podataka, anomalije kod lose projektovanih baza podataka, dekompozicija relacija kod normalizacije i svojstva. Normalizacija: svrha normalizacije i normalne forme, definicije i test normalnih formi (prva, druga, treca normalna forma i Boyce-Codd-ova normalna forma), postupak normalizacije i primeri iz prakse. Uvod u transakcionu obradu: pojam transakcija, ACID svojstva transakcija, transakcije na nivou DBMS-a i potencijalni problemi kod aZururanja, transakcije i oporavak baze podataka. Arhitektura sistema baza podataka, pregled: monolitni sistemi, visekorisnicki, klijent-server sistemi, dvoslojne i troslojne ahitekture, paralelni/distribuirani server baza podataka, fragmentacija podataka.", "RII", "Baze podataka", "Druga", "BP" },
                    { 11, "Definicije. Stepeni cvorova. Predstavljanje. Dijametar, ekscentricitet, radijus, centar. Grafovski nizovi. Putevi u grafu. Povezanost. Komponente povezanosti. Najkraci putevi. Graf grana. Bipartitni graf. Izomorfizam grafova. Spektar grafa. Ojlerovi grafovi. Flerijev algoritam. Problem kineskog postara. Hamiltonovi grafovi. Problem trgovackog putnika. Algoritam najbliZeg suseda. Operacije sa grafovima. Planarni grafovi. Dualni graf. Teorema Ojlera. Stabla. Ciklomatski broj. SpreZna stabla. Minimalna spreZna stabla. Primov, Kraskalov, Mags-Plotkinov algoritam. Transformacije spreZnih stabala. Kodiranje stabla. Spoljasnja i unutrasnja stabilnost grafa. Pokrivanje i uparivanje. Logicki permanent. Fundamentalni ciklusi i preseci. Bojenje grafa.", "RII", "Teorija grafova", "Druga", "TG" },
                    { 12, "Osnove HTML 5. Semanticko oznacavanje elemenata. Napredni koncepti CSS-a. Osnovni koncepti prilagodljivog (Responsive) Veb dizajna. Bogati Veb korisnicki interfejsi i AJAX.  Arhitektura naprednih Veb aplikacija. Domenski vodjeno projektovanje. Projektni obrasci u poslovnim Veb aplikacijama. MVC paradigma pri razvoju Veb aplikacija. Inverzija kontrole. Serijalizacija i prenos podataka, XML i JSON. Objektno-relaciono mapiranje. HTTP protokol. REST Veb servisi. Skalabilnost i postizanje visokih performansi Veb aplikacija.", "RII", "Razvoj Web aplikacija", "Treca", "RWA" },
                    { 13, "Ciljevi. Hardverski koncepti. Softverski koncepti. Klijent-server model. Primeri distribuiranih sistema. Komunikacije u DS.  Modeli Middleware. Pozivi udaljenih procedura. DCE.Pozivi udaljenih objekata. RMI. Komunikacija bazirana na porukama.  MPI. Nacini imenovanja. Sinhronizacija. Sinhronizacija casovnika. Logicki i fizicki casovnik. Lamportove markice. Vektorski casovnici. Sinhronizacija medjusobno uslovljenih dogadjaja. Algoritmi izbora koordinatora. Uzajamno iskljucivanje. Distribuirane transakcije. Konzistentnost i replikacija. Modeli konzistencije. Protokoli. Otpornost na otkaze. Pouzdana klijent-server komunikacija. Pouzdana grupna komunikacija. Distribuirani fajl sistem. Sun network fajl sistem. P2P sistemi.", "RII", "Distribuirani sistemi", "Treca", "DS" },
                    { 14, "Uvod i opsti principi: Predmet i cilj izucavanja teorije igara. Kratki pregled istorije teorije igara. Osnovni pojmovi i definicije teorije igara. Terminologija. Klasifikacija igara. Stratesko razmisljanje. Znacaj i definicije pravila igre. Racionalnost i zajednicko znanje. Pojam ekvilibrijuma. Igre sa simultanim potezima (staticke igre).  Igre sa sekvencijalnim potezima (dinamicke igre). Koncept dominacije (forsiranja). Mesovite strategije i nepredvidivost. Nesov ekvilibrijum. Mesovite igre. Opste klase igara i strategija: Kooperativne i nekooperativne igre. Karakteristicne igre. Strateska upotreba informacija. Strateski i takticki potezi. Primene teorije igara: u informatici, u ekonomiji, politickim i vojnim naukama. Primena u kompjuterskim logickim igrama. Ostale primene.", "RII", "Teorija igara", "Treca", "TIG" },
                    { 15, "Signali kao funkcije, nosioci informacija. Predstavljanje signala, diskretizacija i kvantovanje. Sistem kao automat. Frekventna dekompozicija signala. Teorija odabiranja  signala, Konvolucija, Furijeovi redovi i transformacije. Laplasova i  Z transformacija.", "RII", "Osnovi analize signala i sistema", "Treca", "OASIS" },
                    { 16, "Uvod u sisteme baza podataka: Kratak pregled relacionog modela podataka i relacionih upitnih jezika. Osnovni koncepti sistema baza podataka. Arhitekture sistema baze podataka. Moderni izazovi za Sisteme baza podataka. Napredne tehnike koriscenja SQLa: razliciti tipovi spojeva kod SQLa, set i bag semantika (poredjenje sa relacionom algebrom), rad sa datumima u SQLu, ugnjeZdeni upiti - korelisani i nekorelisani, klauzula CASE, IN i EXIST upiti, kvantifikovani upiti (ALL i ANY), grupisanje podataka i napredne tehnike grupisanja. Sistem za upravljanje bazama podataka: pregled arhitekture, osnovnih modula i funkcija, primeri ovih sistema. Zapamcene procedure, Trigeri: pojam, namena i koriscenje trigera, sintaksa naredbe za kreiranje trigera, tipovi trigera i granularnost, trigeri na nivou vrste i na nivou izraza, redosled izvrsavanja trigera. Obrada i optimizacija upita: pojam optimizacije upita, staticka i dinamicka optimizacija, sistemski katalog, statistika baze podataka i optimizacija, indeksne strukture i visedimenzionalni indeksi. Sigurnost sistema baza podataka: pojam sigurnosti sistema baza podataka, sigurnost kod sistema za upravljanje bazama podataka (DBMS), privilegije korisnika – dodela i oduzimanje (GRANT i REVOKE naredbe), propagacija privilegija, sigurnost na nivou pogleda, statisticke baze podataka, DAC i MAC mehanizam sigurnosti. Objektno-orijentisana paradigma i baze podataka: OO baze podataka, objekat kod OO baza i identitet objekta, OQL i SQL, objektno-relacione baze podataka, objektno-orijentisani i relacioni model podataka – razlike, prednosti i nedostaci, strukturni tipovi kod objektno-relacionih baza podataka, preslikavanje objektno-orijentisanog na relacioni model podataka.", "RII", "Sistemi baza podataka", "Treca", "SBP" },
                    { 17, "Pregled metoda i tehnika za OO projektovanje. Objektno orijentisano projektovanje koriscenjem UML objedinjenog jezika za modeliranje. Identifikacija elemenata projekta. Identifikacija projektnih mehanizama. Opis run-time arhitekture. Projektovanje Use-Case dijagrama. Projektovanje podsistema. Projektovanje klasa: struktura klasa, modeliranje stanja, relacije izmedju klasa. Projektni obrasci. Implementacioni model. Projektovanje komponenata. Distribuiranje aplikacije kroz Web servise. Prednost komponenata sa jednostavnijim klasama. Dekompozicija sistema po procesorima, zadacima i nitima. Preslikavanje projekta na konkurentni sistem. Primer OO projekta realnog sistema.", "RII", "Objektno-orijentisano projektovanje", "Treca", "OOP" },
                    { 18, "Uvod i pregled operativnih sistema. Upravljanje procesima. Niti i upravljanje nitima. Konkurentnost: uzajamno iskljucivanje i sinhronizacija.Uzajamno blokiranje i gladovanje procesa/niti. Upravljanje glavnom memorijom. Virtuelna memorija. Planiranje procesa i niti. Upravljanje U/I i rasporedjivanje pristupa disku.Upravljanje datotekama. Korisnicki interfejsi operativnih sistema. Razmatranje strukture i implementacije aktuelnih operativnih sistema.: UNIX/Linux, MS Windows, itd.", "RII", "Operativni sistemi", "Treca", "OS" },
                    { 19, "Uvod. Istorijat. Upotreba RM. Taksonomija RM. Referentni modeli. ISO/OSI referentni model. Protokoli i servisi. TCP/IP referentni model. Poredjenje referentnih modela. MreZni hardver i softver. Nivo veze za podatke. Kontrola gresaka i kontrola toka. Tehnike za detekciju gresaka. Protokoli sa klizajucim prozorom. Primeri protokola: HDLC, PPP. Lokalne mreZe. Protokoli za emisione kanale. CSMA/CD. IEEE standard 802 za LAN.  Povezivanje mreZe: ripiteri, habovi, mostovi, svicevi. MreZni nivo. Virtuelni kanal. Datagram. Algoritmi za rutiranje. Odredjivanje najkraceg puta. Dijkstrin algoritam. Bujica. “Distance vector” algoritam rutiranja. “Link state” algoritam rutiranja. Hijerarhijsko rutiranje. Kontrola zagusenja. MreZni nivo u Internetu. IP protokol. IP adrese. PodmreZe. NAT. Upravljacki protokoli: ICMP, ARP, DHCP. RIP. Transportni nivo. Transportne usluge. Kvalitet usluga (QoS). Adresiranje. Portovi. Uspostavljanje veze. Multipleksiranje i demultipleksiranje. Internet transportni protokoli: TCP i UDP. Soketi i rad sa soketima.  Aplikativni nivo. MreZne aplikacije i odgovarajuci protokoli DNS, e-mail,  FTP, WWW, HTTP. Bezbednost mreZe i kriptografija. Algoritmi sa tajnim kljucem. DES. Algoritmi sa javnim kljucem. Protokoli za autentifikaciju. Digitalni potpis.", "RII", "Racunarske mreZe", "Treca", "RM" },
                    { 20, "Web kao multimedijalni servis Interneta, HTTP protokol i HTML. Elementi HTML jezika. CSS-Definisanje i upotreba stilova. Programiranje klijenta (Elementi JavaScript jezika). Interaktivne Web aplikacije. Programiranje servera. (CGI, ASP, PHP). Viseslojne Web aplikacije. Osnovne Java tehnologije za Web  programiranje. Elementi XML-a  i njegova primena.  Preslikavanje XML-a u HTML Web servisi. AJAX tehnologija  i Web 2.0.", "RII", "Web programiranje", "Treca", "WP" },
                    { 21, "Uloga i znacaj algoritama. Pojam efikasnosti i sloZenosti algoritma. Paradigme za generisanje algoritama (metod grube sile, iterativni algoritmi, rekurzivni algoritmi, eliminisanje rekurzije, razlaganje (divide-conquer), backtracking, dinamicko programiranje, linearno programiranje). Klasifikacija algoritama (algoritmi za sortiranje, algoritmi traZenja, algoritmi za obradu stringova, algoritmi sa grafovima, geometrijski algoritmi, kriptografski algoritmi, algoritmi za kompresiju datoteka, aritmeticki algoritmi, itd). Tehnike za izracunavanje sloZenosti. Kriterijumi i mere za ocenu sloZenosti algoritama. Osnove analize algoritama: najgori, srednji i najbolji slucaj; empirijsko merenje performansi algoritama. Pregled tehnika dokazivanja. Koriscenje verovatnoce u oceni sloZenosti algoritama.  Strukture podataka i sloZenost operacija za rad sa strukturama podataka. Izbor strukture podataka za implementaciju algoritama. Algoritmi za rad sa stringovima: LCS, Knut-Moris-Pratov algoritam, Bozer-Mooreov algoritam, Rabin-Karpov algoritam, primena konacnih automata. Aproksimativno poklapanje. Sufiksna stabla i sufiksni nizovi. Dinamicko programiranje. Gridi algoritmi. FFT i FFT slicni algoritmi. NP problemi. SAT.", "RII", "Projektovanje i analiza algoritama", "Treca", "PAA" },
                    { 22, "Arhitekture mikroracunarskih sistema. Magistrale mikroracunarskih sistema. Arhitektura mikroprocesora. Programski modeli 16-bitnih i 32-bitnih mikroprocesora. RISC procesori. Nacini organizacije ulaza/izlaza. Programirani ulaz/izlaz. Sistem prekida. Direktan pristup memoriji (DMA). Paralelni U/I. Serijski U/I. Standardni serijski interfejsi (RS 232c, RS 485). Mikroracunar na cipu. Mikrokontroleri. Embeded procesiranje, karakteristike embeded racunara.", "RII", "Mikroracunarski sistemi", "Treca", "MIKS" },
                    { 23, "Uvod (Kratak pregled primene informacionih sistema, Informatika, Informacione tehnologije, Racunarstvo). Osnovni koncepti informacionih sistema (Informacione i komunikacione tehnologije kao tehnoloska osnova informacionih sistema. Organizacioni aspekti informacionih sistema. Tehnoloski aspekti informacionih sistema.) Metodi analize i projektovanja informacionih sistema (Analiza ivodljivosti i predlog sistemskog resenja. Modeliranje i analiza sistema. Projektovanje sistema. Realizacija sistema.) Oblasti primene informacionih sistema za slucaj resenja sa dostupnim izvornim kodom (Open Source). (DMS – Informacioni sistemi za upravljanje i rad sa dokumentima, CMS – Informacioni sistemi za menadZment sadrZaja, JMS – Java Messaging Service kao primer komunikacione infrastrukture informacionih sistema, Informacioni sistemi na nivou strategije, DSS – Informacioni sistemi za podrsku odlucivanju, Informacioni sistemi za podrsku rada sa velikim brojem korisnika – Customer Management Systems, Informacioni sistemi za upravljanje znanjem, Kolaborativni informacioni sistemi.)", "RII", "Informacioni sistemi", "Treca", "IS" },
                    { 24, "Pojam i potreba za softverskim inZenjerstvom. Modeli razvoja softvera. Softverski procesi. Agilni razvoj softvera. Osnovne aktivnosti u upravljanju softverskim projektima. Metode inZenjeringa zahteva. Arhitekture softvera. Projektovanje softvera. Principi realizacije softvera. Validacija i verifikacija. Sistematsko testiranje softvera. Softverske metrike. OdrZavanje i evolucija softvera.", "RII", "Softversko inZenjerstvo", "Treca", "SI" },
                    { 25, "Osnovni pojmovi i istorijski pregled oblasti. Ciljevi interakcije covek-racunar i odnos sa aplikacijama interaktivnog racunarskog sistema. Psiholoski aspekti. Mentalni modeli i projektovanje interfejsa. Uredjaji za interakciju covek-racunar. Paradigme interakcije. Analiza, projektovanje i evaluacija interfejsa covek-racunar. Zivotni ciklus softvera i interakcija covek-racunar. Standardi i vodici za realizaciju korisnickog interfejsa. Alati za razvoj korisnickog interfejsa. Nove paradigme za interakciju: sveprisutno racunarstvo, virtuelna realnost, prosirena realnost, multimodalni interfejsi, hipertekst.", "RII", "Interakcija covek-racunar", "Treca", "INT" },
                    { 26, "Matematicka osnova logickih igara. Matematicki modeli logickih igara - primeri. Opste klase logickih igara. Karakteristicne logicke igre. Osnove algoritama logickih igara. Pojam kompleksnosti i kombinatorne eksplozije. Metode za prevazilaZenje problema kompleksnosti. Metoda heuristickog secenja stabla odlucivanja (forward pruning). Ogranicavanje ekspanzije stabla. Osnovni algoritmi za obradu stabla u logickim igrama. Alfa-Beta,PVS,Null-move,NegaScout,MTD(f),Probe i Multu-Cut ,Quiescence,MVV-LVA i SEE procedure. Pomocne procedure i heuristike (Minimal Window Search, ETC, History,Futility,Contempt factor). Alternativni algoritmi logickih igara - Berlinerov algoritam. Paralelni algoritmi logickih igara. Primena transpozicionih baza u logickim igrama. Evaluacione funkcije. Paralelni i distribuirani algoritmi logickih igara. Client-Server arhitektura kao osnova implementacije logickih igara na internetu. Primeri i analiza instaliranih velikih sistema za daljinsko igranje logickih igara (facebook games, playchess server).", "RII", "Algoritmi logickih igara", "Cetvrta", "ALI" },
                    { 27, "Uvod u servisno-orijentisano racunarstvo (SOC) i servisno-orijentisanu arhitekturu (SOA). Osnovni principi servisno-orijentisanog racunarstva: komunikacija, koordinacija, stanje, sigurnost. Analiza i projektovanje sistema servisno-orijentisane arhitekture. Servisno-orijentisana arhitektura i Web servisi. Osnovne tehnologije Web servisa (SOAP, WSDL i UDDI). REST principi i RESTful Web servisi. Kompozicija, koordinacija i orkestracija servisa. Integracija aplikacija i sistema na nivou organizacije i Enterpise Service Bus (ESB) tehnologije. Sigurnost u servisno-orijentisanoj arhitekturi. Implementacija SOA na razvojnim platformama JavaEE i .NET. Standardi i specifikacije Web servisa. Servisne platforme (OSGi).Servisno-orijentisano racunarstvo i racunarstvo u oblaku.", "RII", "Servisno-orijentisane arhitekture", "Cetvrta", "SOA" },
                    { 29, "Diskretni signali u vremenskom i frekventnom podrucju. Diskretna furieova transformacija (DFT) i Brza Furieova transformacija (FFT), z- transformacija i uopstenja. Kosinusna transformacija. Smplovanje (odabiranje) i rekonstrukcija signala.Diskretni sistemi u vremenskom i frekventnom podrucju. Brza konvolucija. Viserezolucijaska (Multi-rate) obrada signala. Spektralna analiza i kratka kratka (short time) Furijeova transformacija. Projektovanje filtara. Efekti kvantizacije.", "RII", "Metodi i sistemi za obradu signala", "Cetvrta", "MSOS" },
                    { 60, "Ovladavanje naprednim metodama za razvoj i evoluciju softvera i metodama za merenje kvaliteta softverskih proizvoda i procesa.SadrZaj", "RII", "Napredno softversko inZenjerstvo", "Master", "NSI" }
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

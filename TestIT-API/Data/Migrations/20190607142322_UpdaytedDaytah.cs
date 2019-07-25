using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class UpdaytedDaytah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "161f5c50-78e2-4dfb-921c-91ccec04f9da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb4bade-e251-4f0b-863c-9958ffd7cbe6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "995e5679-047e-40e5-9393-cab484c8ae8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb989083-a689-4224-ac07-fdfcccce3d54");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be984901-14e9-489a-af19-ef60d4ad8dd4", "784e8da0-d5a8-4c8a-946d-a423b8307803", "Admin", "ADMIN" },
                    { "74578568-7c30-46f5-987d-b358fc94482c", "3108592c-4620-40c5-b181-f5a5c7499ab8", "Moderator", "MODERATOR" },
                    { "91c08b3c-d2cc-4c20-9729-567122408b7a", "0c3494ed-4e18-4766-a8a7-5fbcb3f1253a", "Student", "STUDENT" },
                    { "34237f2a-3dbf-465a-be09-30ad287a600c", "6f7e3723-d0f9-4a0a-ad06-eacc223ec760", "Profesor", "PROFESOR" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Description", "Module", "Name", "SchoolYear", "Short" },
                values: new object[,]
                {
                    { 73, "Matematička izračunavanja, modelovanje i simulacije, analiza i obrada podataka, grafičko prikazivanje podataka i razvoj algoritama u MATLAB okruženju. Početak rada u  MATLAB-u. Generisanje nizova. Matematičke operacije s nizovima. Skript datoteke. Dvodimenzionalni grafikoni. Funkcije i funkcijske datoteke. Programiranje u MATLAB-u. Trodimenzionalni grafikoni. Primena  MATLAB-a u numeričkoj analizi. Simbolička matematika. Toolboxovi. Grafički programski jezici za kontrolu merne opreme i automatizaciju (LabView, Agilent VEE). Osnovi grafičkog programiranja. Grafički objekti. Pravila izvršenja programa. Kontrola instrumenata. Prikupljanje, obrada i prezentacija podataka. Korišćenje MATLAB koda u grafičkim okruženjima.", "TK", "Softverski alati", "Druga", "SA" },
                    { 72, "Postupci u procesu projektovanja mikrosistema. Osnovne postavke dizajna. Analiza dizajna. Verifikacija dizajna. Projektovanje i analiza mikrosistema pomoću računara (CAD). Principi funkcionisanja komponenti mikrosistema. Materijali za izradu mikrosistema. Tehnologije izrade mikrosistema. Zakoni mehanike i protoka fluida kod projektovanja mikrosistema. Zakoni skaliranja mikrosistema. Analiza mikrosistema na bazi senzora pritiska i mikro-Peltijevog elementa.", "EKM", "Projektovanje mikrosistema", "Cetvrta", "PM" },
                    { 71, "Izvori jednosmernog napona: integrisani ispravljači, prekidački izvori napajanja, filtriranje jednosmernog napona. Osnovni analogni mikroelektronski stepeni: pojačavači u bipolarnoj tehnologiji, pojačavači u MOS tehnologiji, izvori konstantne struje, diferencijalni pojačavači, višestepeni pojačavači. Analogna mikroelektronska kola: operacioni pojačavači, izvori referentnog napona, komparatori, oscilatori, multivibratori, operacioni pojačavači transkonduktanse, integrisani stabilizatori i konvertori jednosmernog napona, pomerači naponskih nivoa, punjači baterija, A/D konvertori.", "EKM", "Analogna mikroelektronika", "Treca", "AM" },
                    { 70, "Pojam signala i sistema, tipovi signala, klasifikacija. Stabilnost. Impulsni odziv. Karakterizacija kontinualnih sistema diferencijalnim jednačinama. Furijeov red. Diskretizacija kontinualnih signala. Realno i idealizovano odmeravanje vremenski kontinualnih signala. Teorema odmeravanja. Impulsni odziv u vremenskom domenu. Konvolucija. Laplasova transformacija. Veza između Laplasove i Furijeove transformacije. Primena Laplasove transformacije na rešavanje linearnih diferencijalnih jednačina. Funkcija prenosa linearnog sistema. Stabilnost sistema. Odziv linearnih kontinualnih sistema na proizvoljnu pobudu.", "EKM", "Signali i sistemi", "Druga", "SS" },
                    { 69, "Energetski resursi u svetu i u Srbiji. Hidroelektrane. Hidraulička energija i snaga vode. Hidrauličke turbine. Tipovi hidroelektrana. Elementi hidroelektrana. Termoelektrane. Osnovni pojmovi termodinamike. Elementi termoelektrana. Parne turbine. Nuklearne elektrane. Termoelektrane sa gasnim turbinama. Ekonomski pokazatelji elektrana. Solarni izvori električne energije. Fotonaponski sistemi. Vetrogeneratori. Vezivanje vetroagregata na mrežu. Male elektrane.", "EEN", "Elektrane", "Cetvrta", "E" },
                    { 68, "Elementi konstrukcije i podela asinhronih mašina. Princip rada. Energetski bilans. Režimi rada. Fizička slika i vektorski dijagram. Ekvivalentna šema. Izraz za elektromagnetni moment i mehanička karakteristika. Stabilnost rada. Uticaj promene parametara i uslova napajanja. Dvobrzinski AM. Kompenzacija reaktivne snage AM. Elementi konstrukcije i podela sinhronih mašina. Režimi rada. Reakcija indukta. Vektorski dijagrami. Analiza rada. Izrazi za aktivnu i reaktivnu snagu. Regulacija aktivne i reaktivne snage. Stabilnost rada. Paralelan rad. Radne karakteristike sinhronih mašina. Specijalni režimi rada.", "EEN", "Masine naizmenicne struje", "Treca", "MNS" },
                    { 66, "Definicija, osnovne karakteristike i primeri sistema za rad u realnom vremenu (RT sistemi). Osnovni principi projektovanja RT sistema – specifikacija zahteva. Metode programiranja – jezici sintaksa, stil, tipovi podataka, kontrolne strukture, podprogrami. Modularno programiranje, apstraktni tipovi podataka, objektno orjentisano programiranje. Visoka pouzdanost, definicije, modeli otkaza, redundansa. Multitasking, preklapanje zadataka, raspoređivanje zadataka. Sinhronizacija i komunikacija zadataka, međusobna isključivost, semafori, redovi čekanja, baferi i zaštićeni objekti. Atomične akcije. Kernel – arhitektura, hardverski model, memorijske mape, periferije, dodela i obrada prekida. Distribuirani sistemi. Definicija, jezici za programiranje. Programiranje na niskom nivou.", "EK", "Sistemi za rad u realnom vremenu", "Cetvrta", "SRRV" },
                    { 74, "Zvuk kao pojava. Karakteristike zvučnog polja. Zvukovodi. Ravanski i sferni talasi. Zvučni izvori. Elektroakustički pretvarači (mikrofoni, slušalice i zvučnici)-konstrukcija, princip rada i karakteristike. Analogije. Akustika prostorija (talasna, statistička i geometrijska teorija). Fiziološka akustika (funkcionisanje čula sluha). Psihološka akustika (subjektivni efekti zvuka). Generisanje i karakteristike govornog i muzičkog signala. Buka. Snimanje, zapisivanje i reprodukcija audio signala. Obrada akustičkih i audio signala.", "TK", "Akustika", "Treca", "A" },
                    { 65, "Prenos podataka i umrežavanje. Mrežne komponente. Nivovski model. Razvoj Interneta. ISO-OSI model. TCP/IP protokol stek. Fizički nivo i novo veze. Signali i električni interfejsi. Asinhroni i sinhroni prenos. Digitalni i analogni prenos. Modulacione tehnike. Multipleksiranje. Detekcija i korekcija grešaka.Upravljanje na nivou veze i protokoli. Pristup tačka ka tački. Proizvoljan pristup, Ethernet. Mrežni nivo, povezivanje, prevođenje mrežne adrese.Prosleđivanje i fragmentacija datagrama. IPv4 i IPv6. Rutiranje. Algoritmi za rutiranje: vektor rastojanja, stanje veze. Podmreže i hijerarhijsko adresiranje. Autonomni sistemi i struktura Interneta. Algoritmi za međudomensko rutiranje. Transportni nivo. Portovi i klijent-server model. UDP. TCP, segmenti, uspostavljanje konekcije, dijagram stanja, kontrola protoka, protokol kliznog prozora, kontrola grešaka. Kontrola zagušenja, priroda zagušenja, model rutera, modeli kontrole zagušenja, spori start, brza retransmisija, brzi oporavak. Aplikacioni nivo. TELNET, FTP, DNS, elektronska pošta. HTTP/Web. Statički, dinamički i aktivni Web dokumenti. Proksi server i keširanje stranica. Sigurnost računarskih mreža. Napadi, zaštite, šifrovanje, autorizovani pristup. Karakteristike bežičnog prenosa, 802.11xx, mobilni IP.", "EK", "Racunarske mreze i interfejsi", "Treca", "RMI" },
                    { 64, "Diode i diodna kola. Bipolarni tranzistor, radna prava i radna tačka. Model bipolarnog tranzistora. MOSFET tranzistor, radna prava i radna tačka. Model MOSFET tranzistora. Osnovni pojačavački stepeni sa bipolarnim i MOSFET tranzistorom. Višestepeni pojačavači. Pojačavač sa direktnom spregom. Diferencijalni i operacioni pojačavač. Primena operacionih pojačavača. Negativna povratna sprega. Oscilatori. Pojačavači velikih signala. Izvori napona napajanja.", "EK", "Osnovi elektronike", "Druga", "OE" },
                    { 63, "Redukcija sistema sila: glavni vektor sile i glavni moment. Uslovi ravnoteže. Kinematika tačke: položaj, konačne jednačine kretanja, brzina, ubrzanje, trajektorija, hodograf vektora brzine i ubrzanja. Kinematika krutog tela. Stepeni slobode. Ugaona brzina i ubrzanje. Dinamika materijalne tačke. Diferencijalne jednačine kretanja. Rad, energija, trenje, kretanje u otpornoj sredini, oscilacije. Dinamika sistema. Opšte teoreme dinamike, konzervativni i nekonzervativni sistemi, potencijal i potencijalna energija. Dinamika krutog tela. Teoreme o količini kretanja i o kinetičkom momentu, vezani koordinatni sistem, diferencijalne jednačine kretanja krutog tela. Analitička mehanika. Mehaničke veze.Holonomna i neholonomna ograničenja, stepeni slobode mehaničkog sistema sa ograničenjima, generalisane koordinate. Koordinate stanja sistema. Dinamika sistema sa ograničenjima. Princip virtuelnih pomeranja. Jednačine kretanja u generalisanim koordinatama. Elementi teorije mehanizama. Kinematički parovi. Kinematički lanci. Mašina alatka i robot kao kinematički lanci. Dinamika mehanizama. Mehanika u tehničkim i biološkim sistemima. Mehanika sklopova i uređaja od značaja za automatsko upravljanje.", "UPS", "Dinamika mehanizma i masina", "Cetvrta", "DMM" },
                    { 62, "Opšta klasifikacija i karakteristike mernih sistema. Merne metode i tehnike kalibracije merila. Greške merenja mernih sistema. Metrološki sistem i sledivost. Izvori mernih signala. Ispitivanje i registrovanje oblika signala. Merenje napona, struje i snage. Merenje frekvencije, faze i vremenskog intervala. Merenje karakteristika signala i sistema. Merenje impedanse, parametara elektronskih kola i poluprovodničkih komponenata. Informacione tehnologije u mernoj instrumentaciji. Virtuelna instrumentacija i vizuelizacija mernih procesa. Interfejs sistemi. Merno-informacioni sistemi.", "UPS", "Elektronska merenja", "Treca", "EM" },
                    { 61, "Osnovni elementi električnih kola sa jednim i dva pristupa. Graf protoka signala. Analiza eletričnih kola u prelaznom režimu primenom klasičnog postupka. Složenoperiodični ustaljeni režim. Analiza kola pomoću Laplasove i z-transformacije. Analiza i sinteza mreža sa dva pristupa. Analiza kola pomoću računara.", "UPS", "Elektricna kola", "Druga", "EK" },
                    { 67, "Osnovni elementi električnih kola. Zavisni izvori. Primena teorije grafova na analizu električnih kola. Odzivi u električnim kolima. Složenoperiodični ustaljeni režim. Rezonancija. Analiza eletričnih kola u prelaznom režimu primenom integro-diferencijalnih jednačina. Analiza kola pomoću Laplasove i  Z-transformacije. Mreže sa više pristupnih krajeva. Parametri i vezivanje mreža sa dva pristupa. Analiza mreža sa raspodeljenim parametrima. Polifazna kola. Uravnotežena i neuravnotežena trofazna kola. Simetrične komponente. Analiza kvarova u trofaznim mrežama. Analiza električnih kola pomoću računara.", "EEN", "Elektricna kola u energetici", "Druga", "EKE" },
                    { 75, "Arhitektura čvora. Pregled operativnih sistema. Arhitektura mreže. Principi projektovanja senzorskih mreža. Fizički sloj. Bežični kanal i komunikacija. Fizički sloj i parametri primopredajnika. MAC protokoli. Protokoli veze podataka. Dodeljivanje imena i adresa. Vremenska sinhronizacija. Uvod u problem vremenske sinhronizacije. Protokoli za vremensku sinhronizaciju. Transportni sloj i kvalitet usluge.", "TK", "Senzorske mreze", "Cetvrta", "SM" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34237f2a-3dbf-465a-be09-30ad287a600c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74578568-7c30-46f5-987d-b358fc94482c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91c08b3c-d2cc-4c20-9729-567122408b7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be984901-14e9-489a-af19-ef60d4ad8dd4");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "161f5c50-78e2-4dfb-921c-91ccec04f9da", "2d75ef00-b7b7-40e5-9eff-3edb25449f32", "Admin", "ADMIN" },
                    { "995e5679-047e-40e5-9393-cab484c8ae8f", "bff0184a-fdc6-4554-bee9-9457172cf7dd", "Moderator", "MODERATOR" },
                    { "eb989083-a689-4224-ac07-fdfcccce3d54", "f4af3c91-b1dd-4295-ae94-f46d5686462b", "Student", "STUDENT" },
                    { "5cb4bade-e251-4f0b-863c-9958ffd7cbe6", "e7652ee4-fc8d-4c15-8b55-a46cc057add1", "Profesor", "PROFESOR" }
                });
        }
    }
}

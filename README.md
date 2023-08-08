# Dokumentacia

### Autor: Jakub Baumgartner

## Zadanie:
Top down strielačka v unity za učelom poraziť všetkých nepriatelov a bossa
### upresnenie:
Vytvoriť fuknčnú top down strielačku v unity ktora bude obsahovať
    - limitaciu životov a nabojov
    - nepriatelov:
        - na diaľku
        - na blizku 
    - system na ukladanie hry
    - power ups:
        - na vyliečenie
        - na zvýšenie maximalného zdravia
        - doplnenie nábojov
        - zväčšenie poškodenie
        - nekonečné náboje
        - nesmrtelnosť
        - zlepšenie videnia hráča
        - rýchlejší pohyb
    - zbrane:
        - základná pištol
        - automatická zbraň
        - brokovnica

## Program

    Program bol vytvorený v Unity engine čo znamená že bol vytvaraný pomocou tzv. Game Object a ich komponentov.
    Tieto komponenty z väčšinou bolo scripty pozostavajúce s klas ktoré dedia od monobeheviour class v unity.
### save system
    Tiež bola vytvorená class *Player Data* služiaca na ukladanie dát hráča ktoré potom budu serializované do Json.
    Serializacia a Deserializacia Json spracuváva statická klasa *save*.
    Hra sa ukladá pri ukončení hry alebo ked si to hrač vyžiada.
    Hra sa skuša načitať vždy pri spustení ale keď hrač chce kliknuť na tlačitko load
    Pri načistani hry sa game object hrača vždy najprv skuša pozrieť či má uložené data a ak ano tak ich načita.
    Save sa vymazava pri prehre alebo keď hrač zvolý novú hru.
### ovladanie hrača
    o ovladanie hrača sa stará klass *controller* a vnej funkcia *update* ktora sa vykonava každý frame hry
    v tejto funkcii sa spušťajú funkcie *Move* stara sa o pohyb hráča spracovava o koľko sa ma hráč pohnuť a ktorým smerom,
    tiež ma nastorosti strialanie hráča. Ďalej spúšťa metodu *Rotate* kde sa počita kde sa má hráč otočiť.
### správanie nepriatelov
    o spravenie sa starajú 3 komponenty, primárnou je *Patrol* v tomto scripte vie vyvojar naplanovať trasu nepriatela po ktorej sa bude pohybovať.
    Pri nepriatelovy na blizku je ešte script *Attack* ktorý ma na storosti zautociť na hrača ak je v dosahu a viditelný.
    pri nepriatelovy na dialku to je *Ranged_Attack*  robi to isté čo *Attack* až na to že na hráča striela pokial je viditelný v určitých intervaloch.
    Nakoniec je tu script *Die* ktorý sa stara ho zdravie nepriatela a jeho následovné zničenie.
### UI
    UI zobrazuje počet životov, nábojov a zbraň ktorú momentalnu zbraň je pomocou toho že si pamätá referenciu na hraču a číta tieto data z referencie.
    UI tiež zobrazuje power up po dobu učinkovania.




## Vstupné Data
Program je ovladaný pomocou klavesnice a myši.
  Klavesi na ovladanie:
    - W **pohyb hore**
    - A **pohyb doľava**
    - S **pohyb dole**
    - D **pohyb doprava**
    - esc **Pauza**
ovladanie pomocou myši:
    hra kontroluje polohu myši na obrazovke a podľa toho otáča hráča na spravný smer.
    Tiež ľavým tlačitkom myši môže hrač strielať

## Nepobolo dokončené
nebol dokončený zaverečný boss kvôli tomu že sa mi nepodarilo implementovať save systém
tak aby fungoval aj cez prechadzanie medzi scenami

## Zaver
    S počiatku som sa bál že bude tažke splniť 45KiB cistého kódu a preto som sa snažil nafuknuť počet mechanik v hre,
čo bola ku koncu podľa mnňa chyba keďže som sa nesustredil na to aby bola hra vyvážená a ako sa hrá ale iba na to aby to 
tam bolo, tiež som sa moc nesustredil na ich implementaciu až tak do hĺbky ako by som mohol a nepremýšlal som moc nad tým ako
s čim bude komunikavať. 
    Tiež som celkom podcenil save system v hre a v unity zistil som si o tom malo a ukazalo sa že je to naročnejšie ako sa zdalo 
a zabralo mi to viac času ako som očakaval. Hlavne kvôli tomu že to fungovalo inač ako som čakal plus som nevedel implementovať ukladanie
uplne ako som si predstavoval napriklad že si hra pamätá koľko nepriatelov bolo na mape v čase ukladania hlavne. V podstate kvôli tomu že som
sa zasekol na zakladnom systeme ukladania a nezostal mi čas ho vylepšiť.
    Kvôli tomuto som tiež neimplementoval Bossa nezostal mi čas na jeho implementaciu hlavne jeho spravania kedže som nemal rozmýslené ako 
by súboj prebiehal.

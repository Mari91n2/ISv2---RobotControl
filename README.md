🎯 Formål

Et simpelt inventar- og ordresystem med en robotarm-simulator (URSim).
Robotten samler varer fra tre bokse (a, b, c) og lægger dem i en forsendelsesboks (S).
Appen viser ordrer og statusbeskeder i et flot GUI lavet med Avalonia UI.

⚙️ Funktioner

Behandler og flytter ordrer fra “Queued” til “Processed”

Viser total omsætning

Viser statusbeskeder som fx:

10:45:01 - 🟡 Processing order...
10:45:03 - 🟢 Picking up items...
10:45:05 - ✅ Order completed!

🖥️ Sådan kører du

Åbn projektet i Visual Studio / Rider

Sørg for at have .NET 9 SDK installeret

Tryk Run

Klik på “Process Next Order” i appen

🧩 Klasser

Order, OrderLine, Item, Customer – håndterer ordrer

MainViewModel – logik og status

ItemSorterRobot – sender URScript til robotten

💬 GUI

Avalonia UI viser:

Køede ordrer

Behandlede ordrer

Statusfelt nederst

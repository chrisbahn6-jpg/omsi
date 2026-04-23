# OMSI 3 - Bus Simulator

Ein vollständiger 3D-Bus-Simulator mit realistischer Physik, Verkehrssystem, Wetter und Fahrgästen.

## Features

- **3D First-Person Perspektive**: Realistische Fahrerkabine
- **Multiple Maps**: Spandau, Grunddorf, Metropole Ruhr, Neudorf
- **Bus-Physik**: Realistische Beschleunigung, Bremsen, Lenkung
- **Routen & Haltestellen**: Definierte Busrouten mit Fahrgästen
- **Verkehrssystem**: KI-gesteuerte Fahrzeuge
- **Wetter-System**: Regen, Schnee, Nebel, Tageszeit
- **Fahrgast-Management**: Auf- und Absteigen, Ticketing

## Projektstruktur

```
Assets/
├── Scripts/
│   ├── Bus/
│   │   ├── BusController.cs
│   │   ├── BusPhysics.cs
│   │   └── BusInput.cs
│   ├── World/
│   │   ├── RouteManager.cs
│   │   ├── BusStopManager.cs
│   │   └── TrafficManager.cs
│   ├── Passenger/
│   │   ├── PassengerSystem.cs
│   │   └── Passenger.cs
│   ├── Weather/
│   │   └── WeatherSystem.cs
│   └── UI/
│       ├── HUD.cs
│       └── MapUI.cs
├── Maps/
│   ├── Spandau/
│   ├── Grunddorf/
│   ├── MetropolRuhr/
│   └── Neudorf/
└── Prefabs/
    ├── Bus.prefab
    ├── Passenger.prefab
    └── Vehicle.prefab
```

## Installation

1. Unity 2022 LTS oder neuer erforderlich
2. Projekt klonen
3. In Unity öffnen
4. Scenes laden und spielen

## Steuerung

- **W/A/S/D**: Fahren
- **Shift**: Gas
- **Space**: Bremse
- **Mouse**: Lenkung
- **E**: Türen öffnen/schließen
- **R**: Route starten/beenden

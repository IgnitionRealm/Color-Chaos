# Ignition Framework v1.0

> **A reusable game development framework for all Ignition Realm games.**

---

# Vision

Ignition Framework is a modular, reusable game framework built on Unity.

Its purpose is to eliminate duplicated code across projects and provide a consistent architecture for browser, Android, desktop, and future console games.

Every game developed by Ignition Realm will be built **on top of this framework**, not around it.

---

# Design Philosophy

The framework follows these principles:

* **SOLID** Principles
* **KISS** (Keep It Simple, Stupid)
* **DRY** (Don't Repeat Yourself)
* **YAGNI** (You Aren't Gonna Need It)

The framework should remain lightweight, readable, and highly reusable.

No feature is added unless a real game requires it.

---

# Goals

* Reuse as much code as possible.
* Separate framework code from game code.
* Support multiple platforms from a single codebase.
* Keep gameplay independent from platform-specific APIs.
* Make adding new games straightforward.
* Build a long-term foundation for Ignition Realm.

---

# Framework Layers

```
Unity Engine
        │
        ▼
Ignition Framework
        │
        ▼
Game Module
        │
        ▼
Game Content
```

---

## Layer Responsibilities

### Unity Engine

Provides rendering, physics, scenes, input, audio, and platform support.

The framework should rely on Unity but should not tightly couple gameplay to Unity-specific systems whenever possible.

---

### Ignition Framework

Contains reusable systems shared by every game.

Examples:

* Managers
* Services
* Events
* Save
* Audio
* Platform
* Input
* UI
* Utilities

This layer must never contain game-specific logic.

---

### Game Module

Contains all logic unique to a specific game.

Examples:

* Color Chaos
* Basketball
* Racing
* Puzzle games

Game modules may use framework systems but must not modify them.

---

### Game Content

Contains project assets.

Examples:

* Scenes
* Prefabs
* Materials
* Fonts
* ScriptableObjects
* Animations

---

# High-Level Folder Structure

```
Assets
│
├── Framework
│   ├── Core
│   ├── Builders
│   ├── Managers
│   ├── Services
│   ├── Events
│   ├── Platform
│   ├── Utilities
│   ├── Pooling
│   └── UI
│
├── Games
│   └── ColorChaos
│
└── Shared
```

Folders will only be created when required.

---

# Core Principles

## Single Responsibility

Every class should have exactly one responsibility.

Example:

* AudioManager controls audio.
* SaveManager controls saves.
* InputManager controls player input.

Managers must never perform unrelated work.

---

## Reusability

If a system can be reused in another game, it belongs inside the Framework.

If it only applies to one game, it belongs inside that game's module.

---

## Platform Independence

Gameplay code should never check:

* Android
* Windows
* WebGL
* CrazyGames
* Poki

Instead, gameplay communicates with the Platform layer.

---

## Modularity

Every major system should be replaceable without affecting unrelated systems.

Examples:

* Local Save → Cloud Save
* CrazyGames Ads → Google Mobile Ads
* Desktop Input → Mobile Input

---

## Predictable Startup

Application startup should always follow the same sequence.

```
Unity
    ↓
Bootstrap
    ↓
AppBuilder
    ↓
App
    ↓
Managers
    ↓
Game
```

This sequence is considered part of the framework contract.

---

# Framework Components

## Core

Responsible for application lifecycle.

Planned classes:

* App
* AppBuilder
* Bootstrap
* ManagerRegistry
* ManagerBase
* IManager

---

## Managers

High-level coordinators.

Managers own systems.

Examples:

* AudioManager
* SaveManager
* InputManager
* PlatformManager
* UIManager
* SceneManager
* GameManager

Managers coordinate work but avoid low-level implementation.

---

## Services

Services perform specialized work.

Examples:

* SaveService
* AudioService
* AdsService
* AnalyticsService

Managers use services.

---

## Events

Loose communication between systems.

Goals:

* Reduce coupling.
* Remove unnecessary direct references.
* Simplify feature expansion.

An Event Bus will be implemented only when a real game requires it.

---

## Utilities

Reusable helper classes.

Examples:

* Math helpers
* Timers
* Extensions
* Random utilities
* General-purpose tools

Utilities must remain independent of gameplay.

---

## Platform Layer

Responsible for platform-specific behavior.

Examples:

* WebGL
* Android
* Windows
* CrazyGames
* Poki
* Steam

Gameplay never communicates directly with platform APIs.

---

## Pooling

Reusable object pooling.

Examples:

* Bullets
* Coins
* Obstacles
* Effects
* Particles

Implemented only when performance requires it.

---

# Development Workflow

Every new system follows this order:

```
Requirement
      ↓
Architecture
      ↓
Review
      ↓
Design Freeze
      ↓
Implementation
      ↓
Testing
      ↓
Git Commit
```

Architecture always comes before implementation.

---

# Rules

## Rule 1

Framework code must never contain game-specific logic.

---

## Rule 2

Game modules must never modify framework code.

---

## Rule 3

A new framework feature is added only after a real requirement appears.

---

## Rule 4

Avoid unnecessary dependencies.

Keep systems isolated.

---

## Rule 5

Code readability is more important than writing fewer lines.

Future maintenance matters more than short-term speed.

---

## Rule 6

Every public class should have a clearly defined responsibility.

If a class starts doing multiple jobs, it should be split.

---

# Versioning

Framework versions follow semantic versioning.

Example:

```
v1.0.0
```

Major changes should be rare.

Gameplay projects should continue working across framework updates whenever practical.

---

# Current Status

## Phase 1

* Repository Created
* Git Connected
* Unity Project Created
* Initial Core Classes
* Architecture Definition

## Next Phase

Finalize the startup architecture and implement it according to this document.

No further architectural changes should be made without a documented reason.

---

# Long-Term Vision

Ignition Framework should become the common foundation for every Ignition Realm project.

The objective is to build a framework that remains maintainable, extensible, and reusable over many years while allowing individual games to focus entirely on gameplay.

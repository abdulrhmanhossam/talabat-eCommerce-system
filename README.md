```mermaid
graph TD
    subgraph PresentationLayer [Presentation Layer - .NET MAUI App]
        UI["UI Components: Buttons, Labels, AR Views"]
        MVVM["MVVM Pattern with CommunityToolkit"]
        HttpClient["HttpClient for API Calls"]
    end

    subgraph ApplicationLayer [Application Layer]
        UseCases["Use Cases: DiagnoseNetwork, SuggestRoaming"]
        Commands["Commands/Queries via MediatR (CQRS)"]
        Services["Business Services: NetworkService, RoamingService"]
    end

    subgraph DomainLayer [Domain Layer]
        Entities["Entities: User, NetworkDiagnosis, RoamingSession"]
        Interfaces["Interfaces: IRepository, IAIIntegration"]
        ValueObjects["Value Objects: SignalStrength, Location"]
    end

    subgraph InfrastructureLayer [Infrastructure Layer]
        Repositories["Repositories: NetworkRepository (EF Core)"]
        DB["Databases: SQL Server (Persistent), Redis (Caching)"]
        AI["AI Integration: Google Gemini SDK"]
        VodafoneAPI["Vodafone APIs: Home Network Check, QoD"]
        External["External Services: HttpClient, SignalR"]
    end

    UI -->|Sends Requests| HttpClient
    HttpClient -->|Calls| ApplicationAPI["API Endpoints in Backend"]
    ApplicationAPI -->|Handles| Commands
    Commands -->|Uses| Services
    Services -->|Depends on| Interfaces
    Interfaces -->|Implemented by| Repositories
    Repositories -->|Access| DB
    Services -->|Calls| AI
    Services -->|Calls| VodafoneAPI
    SignalR["SignalR for Real-time"] -->|Pushes| UI

    DomainLayer -- Defines --> ApplicationLayer
    ApplicationLayer -- Uses --> DomainLayer
    InfrastructureLayer -- Implements --> ApplicationLayer
    PresentationLayer -- Depends on --> ApplicationLayer

    style PresentationLayer fill:#f9f,stroke:#333,stroke-width:2px
    style ApplicationLayer fill:#bbf,stroke:#333,stroke-width:2px
    style DomainLayer fill:#bfb,stroke:#333,stroke-width:2px
    style InfrastructureLayer fill:#fbb,stroke:#333,stroke-width:2px

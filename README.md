```mermaid
graph TD
    subgraph "Presentation Layer" ["Presentation Layer - .NET MAUI App"]
        UI["UI Components: Buttons, Labels, AR Views"]
        MVVM["MVVM Pattern with CommunityToolkit"]
        HttpClient["HttpClient for API Calls"]
    end

    subgraph "Application Layer" ["Application Layer"]
        UseCases["Use Cases: DiagnoseNetwork, SuggestRoaming"]
        Commands["Commands/Queries via MediatR (CQRS)"]
        Services["Business Services: NetworkService, RoamingService"]
    end

    subgraph "Domain Layer" ["Domain Layer"]
        Entities["Entities: User, NetworkDiagnosis, RoamingSession"]
        Interfaces["Interfaces: IRepository, IAIIntegration"]
        ValueObjects["Value Objects: SignalStrength, Location"]
    end

    subgraph "Infrastructure Layer" ["Infrastructure Layer"]
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

    Domain -- Defines --> Application
    Application -- Uses --> Domain
    Infrastructure -- Implements --> Application
    Presentation -- Depends on --> Application

    style "Presentation Layer" fill:#f9f,stroke:#333,stroke-width:2px
    style "Application Layer" fill:#bbf,stroke:#333,stroke-width:2px
    style "Domain Layer" fill:#bfb,stroke:#333,stroke-width:2px
    style "Infrastructure Layer" fill:#fbb,stroke:#333,stroke-width:2px

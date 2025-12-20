# .NET 10.0 Upgrade Migration Plan

## Table of Contents

- [Executive Summary](#executive-summary)
  - [Scope](#scope)
  - [Current State](#current-state)
  - [Target State](#target-state)
  - [Selected Strategy](#selected-strategy)
  - [Complexity Assessment](#complexity-assessment)
  - [Critical Issues](#critical-issues)
- [Migration Strategy](#migration-strategy)
  - [Approach Selection](#approach-selection)
  - [All-at-Once Strategy Rationale](#all-at-once-strategy-rationale)
  - [Dependency-Based Ordering](#dependency-based-ordering)
  - [Execution Decisions](#execution-decisions)
- [Detailed Dependency Analysis](#detailed-dependency-analysis)
  - [Dependency Graph Summary](#dependency-graph-summary)
  - [Project Groupings](#project-groupings)
  - [Critical Path](#critical-path)
- [Project-by-Project Migration Plans](#project-by-project-migration-plans)
  - [Byakkoder.ChakramFF.Entities](#byakkoderchakramffentities)
  - [Byakkoder.ChakramFF.Interfaces](#byakkoderchakramffinterfaces)
  - [Byakkoder.ChakramFF.FFmpegWrapperCore](#byakkoderchakramffffmpegwrappercore)
  - [Byakkoder.ChakramFF.Bootstrapper](#byakkoderchakramffbootstrapper)
  - [Byakkoder.ChakramFF.FFmpegWrapperCore.Test](#byakkoderchakramffffmpegwrappercoretest)
  - [ChakramFF (WinForms Application)](#chakramff-winforms-application)
- [Package Update Reference](#package-update-reference)
  - [Common Package Updates](#common-package-updates)
  - [Project-Specific Package Updates](#project-specific-package-updates)
- [Breaking Changes Catalog](#breaking-changes-catalog)
  - [Windows Forms Breaking Changes](#windows-forms-breaking-changes)
  - [System.Drawing Breaking Changes](#systemdrawing-breaking-changes)
  - [Legacy Configuration System](#legacy-configuration-system)
- [Risk Management](#risk-management)
  - [High-Risk Changes](#high-risk-changes)
  - [Security Vulnerabilities](#security-vulnerabilities)
  - [Contingency Plans](#contingency-plans)
- [Testing & Validation Strategy](#testing--validation-strategy)
  - [Phase Testing Requirements](#phase-testing-requirements)
  - [Smoke Tests](#smoke-tests)
  - [Comprehensive Validation](#comprehensive-validation)
- [Complexity & Effort Assessment](#complexity--effort-assessment)
  - [Per-Project Complexity](#per-project-complexity)
  - [Phase Complexity](#phase-complexity)
  - [Resource Requirements](#resource-requirements)
- [Source Control Strategy](#source-control-strategy)
  - [Branching Strategy](#branching-strategy)
  - [Commit Strategy](#commit-strategy)
  - [Review and Merge Process](#review-and-merge-process)
- [Success Criteria](#success-criteria)
  - [Technical Criteria](#technical-criteria)
  - [Quality Criteria](#quality-criteria)
  - [Process Criteria](#process-criteria)

---

## Executive Summary

### Scope

This plan outlines the migration of the **ChakramFF solution** from **.NET 8.0 to .NET 10.0 (LTS)**. The solution consists of 6 projects forming a Windows Forms desktop application with supporting libraries for FFmpeg video processing.

### Current State

- **6 projects** targeting net8.0/net8.0-windows
- **14,477 lines of code** across 173 files
- **10 NuGet packages** (8 compatible, 2 requiring updates)
- **All projects are SDK-style** (modern project format)
- **Clear dependency hierarchy** with 5 levels (0-4)
- **No circular dependencies**

### Target State

- **All projects** upgraded to net10.0/net10.0-windows
- **2 NuGet packages** updated to net10.0-compatible versions
- **1 legacy package** removed (System.Data.DataSetExtensions - now in framework)
- **4,685+ lines of code** requiring compatibility fixes (primarily in WinForms UI layer)
- **Zero security vulnerabilities** (none detected in current state)

### Selected Strategy

**All-At-Once Strategy** - All projects will be upgraded simultaneously in a single coordinated operation.

**Rationale:**
- Small solution (6 projects)
- All projects currently on .NET 8.0 (homogeneous)
- Simple, clear dependency structure (no circular dependencies)
- All packages have known versions or are compatible
- SDK-style projects throughout (modern tooling)
- Most complexity concentrated in one project (ChakramFF WinForms app)

### Complexity Assessment

**Solution Complexity: Simple**

**Discovered Metrics:**
- **Projects:** 6 (threshold: ?5 for simple, but close)
- **Dependency Depth:** 4 levels (threshold: ?4 for simple) ?
- **High-Risk Projects:** 1 (ChakramFF.csproj - 92.4% LOC impact) 
- **Security Vulnerabilities:** 0 ?
- **Target Framework Heterogeneity:** None (all net8.0 ? net10.0) ?
- **Circular Dependencies:** None ?

**Classification Justification:**
Despite having 6 projects (slightly above the 5-project threshold), this solution is classified as **Simple** because:
1. Five of six projects have zero or minimal API compatibility issues
2. Clean, linear dependency structure
3. All modern SDK-style projects
4. No security vulnerabilities
5. Homogeneous source and target frameworks
6. Single point of complexity (WinForms app) is well-isolated at the top of dependency tree

### Critical Issues

**Windows Forms API Compatibility (4,146 issues)**
- **Impact:** ChakramFF.csproj main application
- **Severity:** Binary incompatible - requires recompilation
- **Nature:** These are primarily designer-generated code references to Windows Forms types that remain available in .NET 10.0-windows but are marked as binary incompatible due to assembly changes
- **Mitigation:** Most issues resolve automatically upon retargeting; manual fixes required only for true breaking changes

**System.Drawing API Compatibility (533 issues)**
- **Impact:** ChakramFF.csproj (graphics and imaging code)
- **Severity:** Source incompatible - requires namespace/API adjustments
- **Mitigation:** Verify using directives; assess for cross-platform alternatives if future plans exist

**Package Updates Required (2 packages)**
- Microsoft.Extensions.Hosting: 8.0.0 ? 10.0.1
- System.Runtime.CompilerServices.Unsafe: 6.0.0 ? 6.1.2

**Legacy Package Removal (1 package)**
- System.Data.DataSetExtensions: Now included in framework reference

### Iteration Strategy

**Fast Batch Approach (2-3 detail iterations):**

**Iteration 2.x:** Foundation sections (Dependency Analysis, Migration Strategy, Risk/Complexity overview)

**Iteration 3.1:** Batch all low-complexity projects (Entities, Interfaces, FFmpegWrapperCore, Bootstrapper, Test)

**Iteration 3.2:** High-complexity project (ChakramFF WinForms application) with detailed breaking changes

**Iteration 3.3:** Final sections (Package updates, Testing strategy, Source control, Success criteria)

This approach leverages the solution's simple structure while giving appropriate attention to the WinForms application's API compatibility challenges.

## Migration Strategy

### Approach Selection

**Selected: All-At-Once Strategy**

**Decision Factors:**

| Factor | Assessment | Supports All-At-Once? |
|--------|------------|----------------------|
| Solution Size | 6 projects, ~14.5k LOC | ? Yes - Small |
| Current Frameworks | All net8.0/net8.0-windows | ? Yes - Homogeneous |
| Target Frameworks | All net10.0/net10.0-windows | ? Yes - Uniform |
| Dependency Structure | 5 levels, no cycles | ? Yes - Clean |
| Package Compatibility | 8/10 compatible, 2 need updates | ? Yes - Clear path |
| API Issues | 4,685 (92% in 1 project) | ? Yes - Isolated complexity |
| Project Style | All SDK-style | ? Yes - Modern tooling |
| Test Coverage | Unit test project exists | ? Yes - Validation available |
| Security Issues | None | ? Yes - No blocking issues |

**Rejected Alternative: Incremental Migration**

Incremental migration would involve upgrading projects in dependency order (Level 0 ? Level 4), requiring multi-targeting for intermediate states. This approach is **not necessary** because:

- **No multi-targeting benefits:** All projects start at net8.0, so no need to maintain backward compatibility during migration
- **Added complexity:** Multi-targeting increases project file complexity and build time without providing value
- **Longer timeline:** Multiple build/test cycles vs. single atomic operation
- **No risk reduction:** The high-risk project (ChakramFF) must be upgraded regardless; delaying it doesn't reduce risk

### All-at-Once Strategy Rationale

**Why This Approach Fits:**

1. **Atomic Simplicity**
   - Single retargeting operation across all projects
   - One build/fix/validate cycle
   - No intermediate multi-targeting states
   - Clear success criteria: solution builds with 0 errors

2. **Complexity Isolation**
   - 92% of API issues concentrated in ChakramFF.csproj
   - Five supporting projects have minimal/zero issues
   - Upgrading all at once surfaces WinForms issues immediately in proper context
   - Dependencies already at target framework when fixing UI layer

3. **Dependency Advantages**
   - Clean hierarchy enables predictable build order
   - No circular dependencies to complicate compilation
   - All projects upgrade together, eliminating version mismatch concerns
   - Single restore operation pulls all correct package versions

4. **Time Efficiency**
   - Fastest path to completion
   - Minimize developer context switching
   - Single testing phase
   - One deployment/release cycle

5. **Modern Project System Support**
   - All SDK-style projects simplify retargeting (single property change)
   - NuGet automatic version resolution handles package updates
   - MSBuild 17+ handles multi-framework builds efficiently if needed later

### Dependency-Based Ordering

While all projects upgrade simultaneously, understanding the **logical build order** helps with troubleshooting if compilation issues arise:

**Build Order (MSBuild determines automatically):**

1. **Byakkoder.ChakramFF.Entities** (no dependencies)
2. **Byakkoder.ChakramFF.Interfaces** (? Entities)
3. **Byakkoder.ChakramFF.FFmpegWrapperCore** (? Interfaces)
4. **Byakkoder.ChakramFF.Bootstrapper** (? Interfaces, Entities, FFmpegWrapperCore)
5. **Byakkoder.ChakramFF.FFmpegWrapperCore.Test** (? Interfaces, Entities, FFmpegWrapperCore)
6. **ChakramFF** (? all core libraries)

**Error Isolation Strategy:**

If build errors occur after retargeting:
- **Entities/Interfaces/FFmpegWrapperCore errors:** Address first (unlikely - minimal API issues)
- **Bootstrapper errors:** Likely package-related (Microsoft.Extensions.Hosting update)
- **ChakramFF errors:** Expected (4,683 API issues) - address after dependencies build successfully
- **Test errors:** Address after main projects build successfully

This ordering ensures foundation issues don't cascade into false positives in dependent projects.

### Execution Decisions

**Parallel vs. Sequential:**

- **Project Retargeting:** Parallel (all TargetFramework properties updated simultaneously)
- **Package Updates:** Parallel (all PackageReference updates applied simultaneously)
- **Build:** MSBuild determines order based on dependencies (automatic parallelization where possible)
- **Error Fixing:** Sequential by dependency level (bottom-up: fix Entities before Interfaces, etc.)
- **Testing:** Sequential (unit tests after all projects build, then integration validation)

**Single-Pass Operation:**

The All-At-Once strategy treats the upgrade as a **single atomic operation**:

1. **Update Phase:** All project files and package references updated in one pass
2. **Restore Phase:** Single `dotnet restore` for entire solution
3. **Build Phase:** Single `dotnet build` for entire solution (surfaces all errors at once)
4. **Fix Phase:** Address compilation errors (focus on ChakramFF WinForms issues)
5. **Rebuild Phase:** Verify all fixes applied correctly
6. **Test Phase:** Execute test project to validate core functionality
7. **Commit Phase:** Single commit with all changes (atomic transaction)

**Risk Management:**

- **Pre-upgrade backup:** Working branch already created (`upgrade-to-NET10`)
- **Source branch:** Clean state on `main` branch
- **Rollback plan:** `git reset --hard` to pre-upgrade commit if needed
- **Validation gates:** Build must succeed before testing; tests must pass before merge

**Timeline:**

All operations occur in a **single coordinated session** with no intermediate states:

| Phase | Activities | Expected Outcome |
|-------|-----------|------------------|
| **Atomic Update** | Update all project files, update all packages, restore dependencies | Solution ready to build |
| **Build & Fix** | Build solution, fix compilation errors, rebuild to verify | 0 errors, 0 warnings |
| **Test Validation** | Run unit tests, address test failures | All tests pass |
| **Final Validation** | Full solution rebuild, confirm clean state | Ready for commit |

No phases execute in isolation - this is a continuous flow from retargeting to validation.

## Detailed Dependency Analysis

### Dependency Graph Summary

The ChakramFF solution has a clean, hierarchical dependency structure with **5 levels** (0-4) and **no circular dependencies**. This linear structure is ideal for an All-At-Once upgrade approach.

```
Level 0 (Foundation):
  ?? Byakkoder.ChakramFF.Entities (0 dependencies)

Level 1:
  ?? Byakkoder.ChakramFF.Interfaces (? Entities)

Level 2:
  ?? Byakkoder.ChakramFF.FFmpegWrapperCore (? Interfaces)

Level 3:
  ?? Byakkoder.ChakramFF.Bootstrapper (? Interfaces, Entities, FFmpegWrapperCore)
  ?? Byakkoder.ChakramFF.FFmpegWrapperCore.Test (? Interfaces, Entities, FFmpegWrapperCore)

Level 4 (Top):
  ?? ChakramFF (? Interfaces, Entities, Bootstrapper, FFmpegWrapperCore)
```

**Dependency Relationships:**
- **Entities** is the foundation (used by all projects)
- **Interfaces** depends only on Entities (used by 4 projects)
- **FFmpegWrapperCore** depends on Interfaces (used by 3 projects + test)
- **Bootstrapper** depends on Interfaces, Entities, FFmpegWrapperCore (used by ChakramFF)
- **Test project** mirrors FFmpegWrapperCore dependencies (leaf node)
- **ChakramFF** (main app) depends on all core libraries (leaf node)

### Project Groupings

For the All-At-Once strategy, all projects will be upgraded simultaneously. However, understanding the logical groupings helps with validation and troubleshooting:

**Group 1: Core Domain Models**
- Byakkoder.ChakramFF.Entities (Level 0)
  - Pure data models
  - Zero API compatibility issues
  - Foundation for all other projects

**Group 2: Abstraction Layer**
- Byakkoder.ChakramFF.Interfaces (Level 1)
  - Interface definitions
  - Depends only on Entities
  - Zero API compatibility issues

**Group 3: FFmpeg Processing Engine**
- Byakkoder.ChakramFF.FFmpegWrapperCore (Level 2)
  - Core FFmpeg wrapper logic
  - 1 source incompatibility issue (minor)
  - Business logic layer

**Group 4: Composition & Testing**
- Byakkoder.ChakramFF.Bootstrapper (Level 3)
  - Dependency injection setup
  - 1 package update required (Microsoft.Extensions.Hosting)
  - Zero API compatibility issues
- Byakkoder.ChakramFF.FFmpegWrapperCore.Test (Level 3)
  - Unit tests for FFmpegWrapperCore
  - 1 source incompatibility issue (minor)
  - Validates core functionality

**Group 5: User Interface**
- ChakramFF (Level 4)
  - Windows Forms application
  - **High complexity:** 4,683+ API compatibility issues
  - 2 package updates + 1 legacy package removal
  - Primary risk area

### Critical Path

The critical path for this upgrade follows the dependency chain from foundation to UI:

**Entities ? Interfaces ? FFmpegWrapperCore ? Bootstrapper ? ChakramFF**

**All-At-Once Considerations:**
1. **Atomic Operation:** All projects retarget simultaneously to avoid intermediate multi-targeting complexity
2. **Dependency Validation:** After bulk update, restore and build will validate dependency compatibility in one pass
3. **Failure Isolation:** If build fails, the dependency structure makes it clear where to focus (likely ChakramFF due to WinForms API changes)
4. **Test Execution:** Test project runs after all libraries build successfully
5. **Single Commit:** All changes can be committed atomically, maintaining solution integrity

**Why No Circular Dependencies Matter:**
- Clean build order (no special MSBuild handling needed)
- Clear validation sequence
- Easier rollback if needed
- Predictable compilation order

## Project-by-Project Migration Plans

### Byakkoder.ChakramFF.Entities

**Current State:** net8.0, ClassLibrary, 26 files, 1,329 LOC, 0 dependencies, SDK-style

**Target State:** net10.0

**Complexity:** ?? Low

**Risk Level:** ?? Low

#### Migration Steps

**1. Prerequisites**

None. This is the foundation project with no dependencies.

**2. Target Framework Update**

Update `Byakkoder.ChakramFF.Entities\Byakkoder.ChakramFF.Entities.csproj`:

```xml
<TargetFramework>net10.0</TargetFramework>
```

**3. Package/Dependency Updates**

None. Project has no NuGet package dependencies.

**4. Expected Breaking Changes**

None. Assessment shows 0 API compatibility issues.

**5. Code Modifications**

None expected. This project contains pure data models (entities) with no framework-specific API usage.

**6. Testing Strategy**

- **Build validation:** Project must build with 0 errors and 0 warnings
- **Dependent project validation:** All projects that reference Entities must continue to build successfully
- **No unit tests:** Project is data models only (tested transitively through dependent projects)

**7. Validation Checklist**

- [ ] `Byakkoder.ChakramFF.Entities.csproj` TargetFramework is `net10.0`
- [ ] Project builds without errors
- [ ] Project builds without warnings
- [ ] No package dependency conflicts
- [ ] Dependent projects (Interfaces, FFmpegWrapperCore, Bootstrapper, FFmpegWrapperCore.Test, ChakramFF) can resolve Entities successfully

---

### Byakkoder.ChakramFF.Interfaces

**Current State:** net8.0, ClassLibrary, 30 files, 925 LOC, 1 dependency (Entities), SDK-style

**Target State:** net10.0

**Complexity:** ?? Low

**Risk Level:** ?? Low

#### Migration Steps

**1. Prerequisites**

- Byakkoder.ChakramFF.Entities successfully retargeted to net10.0 (in same atomic operation)

**2. Target Framework Update**

Update `Byakkoder.ChakramFF.Interfaces\Byakkoder.ChakramFF.Interfaces.csproj`:

```xml
<TargetFramework>net10.0</TargetFramework>
```

**3. Package/Dependency Updates**

None. Project has no NuGet package dependencies. ProjectReference to Entities automatically resolves to net10.0 version.

**4. Expected Breaking Changes**

None. Assessment shows 0 API compatibility issues.

**5. Code Modifications**

None expected. This project contains interface definitions with no framework-specific API usage.

**6. Testing Strategy**

- **Build validation:** Project must build with 0 errors and 0 warnings
- **Dependent project validation:** All projects that reference Interfaces must continue to build successfully
- **No unit tests:** Project is interface definitions only (tested transitively through implementations)

**7. Validation Checklist**

- [ ] `Byakkoder.ChakramFF.Interfaces.csproj` TargetFramework is `net10.0`
- [ ] Project builds without errors
- [ ] Project builds without warnings
- [ ] No package dependency conflicts
- [ ] ProjectReference to Entities resolves correctly
- [ ] Dependent projects (FFmpegWrapperCore, Bootstrapper, FFmpegWrapperCore.Test, ChakramFF) can resolve Interfaces successfully

---

### Byakkoder.ChakramFF.FFmpegWrapperCore

**Current State:** net8.0, ClassLibrary, 44 files, 3,127 LOC, 1 dependency (Interfaces), SDK-style

**Target State:** net10.0

**Complexity:** ?? Low

**Risk Level:** ?? Low

#### Migration Steps

**1. Prerequisites**

- Byakkoder.ChakramFF.Interfaces successfully retargeted to net10.0 (in same atomic operation)
- Byakkoder.ChakramFF.Entities successfully retargeted to net10.0 (transitive via Interfaces)

**2. Target Framework Update**

Update `Byakkoder.ChakramFF.FFmpegWrapperCore\Byakkoder.ChakramFF.FFmpegWrapperCore.csproj`:

```xml
<TargetFramework>net10.0</TargetFramework>
```

**3. Package/Dependency Updates**

None. Project has no NuGet package dependencies. ProjectReference to Interfaces automatically resolves to net10.0 version.

**4. Expected Breaking Changes**

Assessment identifies **1 source incompatible API** (specific API not detailed in assessment). Likely candidates:

- **Namespace changes:** A type moved to a different namespace in .NET 10.0
- **Method signature changes:** A parameter type or return type changed
- **Obsolete API removal:** A deprecated API from .NET 8.0 removed in .NET 10.0

**Common patterns to watch:**
- File I/O APIs (System.IO namespace changes)
- Process invocation (for FFmpeg process management)
- String manipulation or encoding APIs

**5. Code Modifications**

**Phase 1: Build to Identify Issue**

Build project after retargeting. Compilation error message will identify specific API incompatability.

**Phase 2: Apply Fix Based on Error**

Likely fixes (apply based on actual error):

**If namespace change:**
```csharp
// Add or update using directive
using NewNamespace;
```

**If method signature change:**
```csharp
// Before (example)
ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);

// After (example - if signature changed)
ProcessStartInfo psi = new ProcessStartInfo
{
    FileName = fileName,
    Arguments = arguments
};
```

**If obsolete API removed:**
Consult .NET 10.0 breaking changes documentation for replacement API.

**6. Testing Strategy**

- **Build validation:** Project must build with 0 errors and 0 warnings after fix applied
- **Unit tests:** FFmpegWrapperCore.Test project contains tests for this library (run after fixing test project)
- **Integration validation:** Verify FFmpeg operations work correctly (file conversions, metadata extraction, etc.)

**7. Validation Checklist**

- [ ] `Byakkoder.ChakramFF.FFmpegWrapperCore.csproj` TargetFramework is `net10.0`
- [ ] Source incompatibility identified and fixed
- [ ] Project builds without errors
- [ ] Project builds without warnings
- [ ] No package dependency conflicts
- [ ] ProjectReference to Interfaces resolves correctly
- [ ] Dependent projects (Bootstrapper, FFmpegWrapperCore.Test, ChakramFF) can resolve FFmpegWrapperCore successfully
- [ ] Unit tests pass (validated via FFmpegWrapperCore.Test project)

---

### Byakkoder.ChakramFF.Bootstrapper

**Current State:** net8.0, ClassLibrary, 1 file, 128 LOC, 3 dependencies (Interfaces, Entities, FFmpegWrapperCore), SDK-style

**Target State:** net10.0

**Complexity:** ?? Low

**Risk Level:** ?? Low

#### Migration Steps

**1. Prerequisites**

- Byakkoder.ChakramFF.Interfaces successfully retargeted to net10.0 (in same atomic operation)
- Byakkoder.ChakramFF.Entities successfully retargeted to net10.0 (in same atomic operation)
- Byakkoder.ChakramFF.FFmpegWrapperCore successfully retargeted to net10.0 (in same atomic operation)

**2. Target Framework Update**

Update `Byakkoder.ChakramFF.Bootstrapper\Byakkoder.ChakramFF.Bootstrapper.csproj`:

```xml
<TargetFramework>net10.0</TargetFramework>
```

**3. Package/Dependency Updates**

Update Microsoft.Extensions.Hosting package in `Byakkoder.ChakramFF.Bootstrapper\Byakkoder.ChakramFF.Bootstrapper.csproj`:

**Current:**
```xml
<PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.0" />
```

**Target:**
```xml
<PackageReference Include="Microsoft.Extensions.Hosting" Version="10.0.1" />
```

**Reason for Update:** Align with .NET 10.0 framework version. Version 10.0.1 includes performance improvements and bug fixes. Semantic versioning indicates backward compatibility (no breaking changes from 8.0.0 to 10.0.1).

**4. Expected Breaking Changes**

None. Assessment shows 0 API compatibility issues. Microsoft.Extensions.Hosting 10.0.1 maintains backward compatibility with 8.0.0 API surface.

**5. Code Modifications**

None expected. This project contains dependency injection configuration using standard Microsoft.Extensions.Hosting APIs that remain stable across versions.

**Verify after build:**
- Service registration methods (e.g., `AddSingleton`, `AddTransient`, `AddScoped`)
- Host builder configuration
- Lifetime management APIs

All should continue working without modification.

**6. Testing Strategy**

- **Build validation:** Project must build with 0 errors and 0 warnings
- **Dependency injection validation:** Verify service resolution works correctly (tested transitively through ChakramFF application startup)
- **Host lifetime validation:** Ensure application start/stop lifecycle works as expected

**7. Validation Checklist**

- [ ] `Byakkoder.ChakramFF.Bootstrapper.csproj` TargetFramework is `net10.0`
- [ ] Microsoft.Extensions.Hosting package updated to version 10.0.1
- [ ] Project builds without errors
- [ ] Project builds without warnings
- [ ] No package dependency conflicts
- [ ] ProjectReferences to Interfaces, Entities, FFmpegWrapperCore resolve correctly
- [ ] Dependent project (ChakramFF) can resolve Bootstrapper successfully
- [ ] Service resolution works correctly at application startup (tested via ChakramFF)

---

### Byakkoder.ChakramFF.FFmpegWrapperCore.Test

**Current State:** net8.0, DotNetCoreApp (Test), 36 files, 3,899 LOC, 3 dependencies (Interfaces, Entities, FFmpegWrapperCore), SDK-style

**Target State:** net10.0

**Complexity:** ?? Low

**Risk Level:** ?? Low

#### Migration Steps

**1. Prerequisites**

- Byakkoder.ChakramFF.Interfaces successfully retargeted to net10.0 (in same atomic operation)
- Byakkoder.ChakramFF.Entities successfully retargeted to net10.0 (in same atomic operation)
- Byakkoder.ChakramFF.FFmpegWrapperCore successfully retargeted to net10.0 and source incompatibility fixed (in same atomic operation)

**2. Target Framework Update**

Update `Byakkoder.ChakramFF.FFmpegWrapperCore.Test\Byakkoder.ChakramFF.FFmpegWrapperCore.Test.csproj`:

```xml
<TargetFramework>net10.0</TargetFramework>
```

**3. Package/Dependency Updates**

No package version updates required. Current packages are compatible:

| Package | Current Version | Status |
|---------|----------------|--------|
| coverlet.collector | 6.0.0 | FFmpegWrapperCore.Test | Code coverage collector for tests |
| Microsoft.NET.Test.Sdk | 17.8.0 | FFmpegWrapperCore.Test | Test platform SDK |
| Moq | 4.20.70 | FFmpegWrapperCore.Test | Mocking framework for tests |
| MSTest.TestAdapter | 3.1.1 | FFmpegWrapperCore.Test | MSTest test adapter |
| MSTest.TestFramework | 3.1.1 | FFmpegWrapperCore.Test | MSTest test framework |
| Unity | 5.11.7 | ChakramFF | Dependency injection container |

ProjectReferences to Interfaces, Entities, FFmpegWrapperCore automatically resolve to net10.0 versions.

**4. Expected Breaking Changes**

Assessment identifies **1 source incompatible API** (specific API not detailed in assessment). This is likely the **same incompatibility** as in Byakkoder.ChakramFF.FFmpegWrapperCore, manifesting in test code that uses the affected API.

**Likely scenario:**
- FFmpegWrapperCore fix (from previous section) already addresses the root cause
- Test code may also use the same API directly
- Test setup/mocking code may reference the affected type or method

**5. Code Modifications**

**Phase 1: Build to Identify Issue**

Build project after retargeting. If compilation error occurs, it will identify the specific API incompatibility.

**Phase 2: Apply Fix Based on Error**

**If same issue as FFmpegWrapperCore:**
Apply the same fix pattern used in FFmpegWrapperCore to test code.

**If test-specific issue:**

- Update references or Usings in test code as required
- Fix any outdated mocking setups (e.g., Moq) to match new signatures or namespaces

**6. Testing Strategy**

- **Build validation:** Project must build with 0 errors and 0 warnings
- **Unit tests:** Run all unit tests to validate core logic (ensure no failures)
- **Integration tests:** If any integration tests exist, verify end-to-end functionality

**7. Validation Checklist**

- [ ] `Byakkoder.ChakramFF.FFmpegWrapperCore.Test.csproj` TargetFramework is `net10.0`
- [ ] Source incompatibility identified and fixed
- [ ] Project builds without errors
- [ ] Project builds without warnings
- [ ] No package dependency conflicts
- [ ] ProjectReferences to Interfaces, Entities, FFmpegWrapperCore resolve correctly
- [ ] Unit tests pass (validated via test runner)

---

### ChakramFF (WinForms Application)

**Current State:** net8.0-windows, WinForms, 55 files, 5,069 LOC, 4 dependencies (Interfaces, Entities, Bootstrapper, FFmpegWrapperCore), SDK-style

**Target State:** net10.0-windows

**Complexity:** ?? Medium

**Risk Level:** ?? Medium

#### Migration Steps

**1. Prerequisites**

- Byakkoder.ChakramFF.Interfaces successfully retargeted to net10.0 (in same atomic operation)
- Byakkoder.ChakramFF.Entities successfully retargeted to net10.0 (in same atomic operation)
- Byakkoder.ChakramFF.Bootstrapper successfully retargeted to net10.0 and package updated (in same atomic operation)
- Byakkoder.ChakramFF.FFmpegWrapperCore successfully retargeted to net10.0 and source incompatibility fixed (in same atomic operation)

**2. Target Framework Update**

Update `ChakramFF\ChakramFF.csproj`:

```xml
<TargetFramework>net10.0-windows</TargetFramework>
```

**Note:** The `-windows` suffix is **required** for Windows Forms applications. This enables Windows Desktop APIs including Windows Forms and System.Drawing.

**3. Package/Dependency Updates**

**Update System.Runtime.CompilerServices.Unsafe:**

**Current:**
```xml
<PackageReference Include="System.Runtime.CompilerServices.Unsafe" Version="6.0.0" />
```

**Target:**
```xml
<PackageReference Include="System.Runtime.CompilerServices.Unsafe" Version="6.1.2" />
```

**Reason:** Version 6.1.2 provides compatibility improvements for .NET 10.0 and includes performance optimizations. Transitive dependency used by several packages (Unity, potentially others).

**Remove System.Data.DataSetExtensions:**

**Current:**
```xml
<PackageReference Include="System.Data.DataSetExtensions" Version="4.5.0" />
```

**Action:** Delete this PackageReference entirely.

**Reason:** System.Data.DataSetExtensions functionality is now included directly in the .NET 10.0 framework. The package is redundant and can cause conflicts. All DataSet extension methods (e.g., `.AsEnumerable()`, `.CopyToDataTable()`) remain available without the package.

**Keep Existing Packages (No Updates Required):**

| Package | Version | Projects | Notes |
|---------|---------|----------|-------|
| coverlet.collector | 6.0.0 | FFmpegWrapperCore.Test | Code coverage collector for tests |
| Microsoft.CSharp | 4.7.0 | ChakramFF | Dynamic language runtime support |
| Microsoft.NET.Test.Sdk | 17.8.0 | FFmpegWrapperCore.Test | Test platform SDK |
| Moq | 4.20.70 | FFmpegWrapperCore.Test | Mocking framework for tests |
| MSTest.TestAdapter | 3.1.1 | FFmpegWrapperCore.Test | MSTest test adapter |
| MSTest.TestFramework | 3.1.1 | FFmpegWrapperCore.Test | MSTest test framework |
| Unity | 5.11.7 | ChakramFF | Dependency injection container |

**4. Expected Breaking Changes**

**Assessment Summary:**
- **4,683 total API issues** (4,146 binary incompatible, 537 source incompatible)
- **Technologies affected:** Windows Forms (88.5%), System.Drawing (11.4%), Legacy Configuration (0.1%)
- **Estimated LOC impact:** 4,683+ (92.4% of project)

**?? Important Context:** The majority of these issues are **designer-generated code** references to Windows Forms types. These types remain fully available in .NET 10.0-windows but are flagged as "binary incompatible" due to assembly location changes. **Most issues will resolve automatically upon retargeting** without manual code changes.

**Manual Fixes Required:**

**A. System.Drawing Source Incompatibilities (537 issues)**

**Issue Pattern:** `System.Drawing.Bitmap` and related types are **source incompatible** (require using directives or namespace adjustments).

**Affected Files:**
- `ChakramFF\Properties\Resources.Designer.cs` - Resource file accessor properties
- Form files with custom graphics code

**Expected Fix:**

Ensure proper using directive exists at top of files:
```csharp
using System.Drawing;
```

**Resources.Designer.cs** typically has this already, but verify after build. If compilation errors occur related to `Bitmap`, `Font`, `GraphicsUnit`, etc., add:

```csharp
using System.Drawing;
using System.Drawing.Drawing2D; // If using advanced graphics
using System.Drawing.Imaging;   // If using image formats
```

**B. Windows Forms Event Handler Signatures**

**Potential Issue:** Some event handler signatures may have changed in .NET 10.0.

**Common pattern:**
```csharp
// If compilation error on event handler
private void Button_Click(object sender, EventArgs e)
{
    // Implementation
}
```

**Likely fix:** Signature remains same in most cases. If error occurs, check event handler signature matches expected delegate type.

**C. Legacy Configuration System (4 issues)**

**Issue:** Usage of `System.Configuration.ConfigurationManager` or app.config-based settings.

**Location:** Search codebase for:
- `ConfigurationManager.AppSettings`
- `ConfigurationManager.ConnectionStrings`
- References to `app.config`

**Fix Options:**

**Option 1 (Bridge):** Add NuGet package for temporary compatibility:
```xml
<PackageReference Include="System.Configuration.ConfigurationManager" Version="10.0.0" />
```

**Option 2 (Recommended):** Migrate to modern configuration:
```csharp
// Old (app.config)
string setting = ConfigurationManager.AppSettings["SettingName"];

// New (appsettings.json + Microsoft.Extensions.Configuration)
string setting = configuration["SettingName"];
```

If minimal usage, Option 1 (bridge package) is faster. If extensive configuration, consider Option 2 for long-term maintainability.

**D. Designer-Generated Code (4,146 binary incompatible issues)**

**Issue Pattern:** Windows Forms designer generates code like:

```csharp
this.button1 = new System.Windows.Forms.Button();
this.panel1 = new System.Windows.Forms.Panel();
// ... etc.
```

These types are flagged as "binary incompatible" because they moved from `System.Windows.Forms.dll` to different assemblies in .NET Core/5+. However, **all types remain available** in .NET 10.0-windows with the same public API surface.

**Expected Behavior:**
- **Most issues auto-resolve** upon retargeting (compiler automatically references correct assemblies)
- **No code changes required** in most cases
- **Designer files regenerate** automatically when forms are opened in Visual Studio designer

**Manual Intervention Only If:**
- Compilation errors occur after build (rare)
- Designer fails to load a form (regenerates designer file)
- Custom control initialization fails (update control library references if needed)

**5. Code Modifications**

**Phase 1: Build to Identify Issues**

After retargeting and updating packages, build the project:

```bash
dotnet build ChakramFF\ChakramFF.csproj
```

**Expected outcome:** Some compilation errors related to System.Drawing using directives or configuration APIs.

**Phase 2: Fix Compilation Errors**

**Priority Order:**

1. **System.Drawing using directives** - Add `using System.Drawing;` to files with errors
2. **Legacy configuration** - Add bridge package or migrate to modern configuration
3. **Custom graphics code** - Address namespace changes in custom painting/rendering code
4. **Designer issues** - Regenerate designer files if needed (rare)

**Phase 3: Rebuild to Verify**

```bash
dotnet build ChakramFF\ChakramFF.csproj
```

**Expected outcome:** 0 errors, 0 warnings.

**6. Testing Strategy**

**Critical: Windows Forms applications require thorough manual testing** beyond compilation success.

**Build Validation:**
- [ ] Project builds with 0 errors
- [ ] Project builds with 0 warnings
- [ ] No package dependency conflicts

**Functional Validation (Manual Testing):**

**A. Application Startup**
- [ ] Application launches successfully
- [ ] Main form renders correctly
- [ ] All controls visible and positioned correctly
- [ ] Dependency injection / bootstrapper initializes services correctly

**B. Core User Workflows**

Test key application features:

- [ ] **Single File Conversion:** Select video file, configure settings, execute conversion
- [ ] **Multiple Files Conversion:** Select multiple video files, batch convert
- [ ] **Preview Functionality:** Preview video before/after conversion
- [ ] **Settings Management:** Open settings dialog, modify settings, save successfully
- [ ] **FFmpeg Operations:** Verify FFmpeg process launches and completes successfully
- [ ] **Progress Tracking:** Conversion progress updates correctly
- [ ] **Error Handling:** Invalid inputs show appropriate error messages

**C. UI Component Validation**

- [ ] **Buttons:** All buttons render correctly, click events fire
- [ ] **Panels:** Layout panels render correctly
- [ ] **Labels:** Text labels display correct content
- [ ] **TextBoxes:** Input controls accept text correctly
- [ ] **PictureBoxes:** Images/icons display correctly
- [ ] **Dialogs:** Modal dialogs open and close correctly
- [ ] **Menus:** Context menus and menu bars work correctly (if present)

**D. Graphics/GDI+ Validation**

- [ ] **Icons:** All toolbar/button icons render correctly
- [ ] **Custom Painting:** Any custom-drawn controls render correctly
- [ ] **Image Resources:** All embedded image resources load correctly
- [ ] **Font Rendering:** All fonts render correctly at all sizes

**E. Integration Validation**

- [ ] **Bootstrapper:** DI container resolves services correctly
- [ ] **FFmpegWrapperCore:** FFmpeg operations execute successfully
- [ ] **Data Entities:** Data models serialize/deserialize correctly
- [ ] **Interfaces:** All interface implementations function correctly

**F. Performance Validation**

- [ ] **Application startup time:** No significant degradation
- [ ] **Form loading time:** All forms open promptly
- [ ] **FFmpeg operations:** Video processing performance similar to .NET 8.0 version
- [ ] **Memory usage:** No memory leaks during conversion operations

**Automated Testing:**
- [ ] FFmpegWrapperCore.Test unit tests pass (validates core logic)

**7. Validation Checklist**

- [ ] `ChakramFF.csproj` TargetFramework is `net10.0-windows`
- [ ] System.Runtime.CompilerServices.Unsafe package updated to version 6.1.2
- [ ] System.Data.DataSetExtensions package removed
- [ ] Microsoft.CSharp and Unity packages remain at current versions
- [ ] All System.Drawing using directives present where needed
- [ ] Legacy configuration issues resolved (bridge package or migration)
- [ ] Project builds without errors
- [ ] Project builds without warnings
- [ ] No package dependency conflicts
- [ ] ProjectReferences to Interfaces, Entities, Bootstrapper, FFmpegWrapperCore resolve correctly
- [ ] Application launches successfully
- [ ] All forms render correctly
- [ ] Core user workflows function correctly
- [ ] No visual regressions in UI
- [ ] FFmpeg operations complete successfully
- [ ] Performance is acceptable
- [ ] FFmpegWrapperCore.Test unit tests pass

**Known Acceptable Warnings:**

````````

This is the description of what the code block changes:
Fill remaining sections: Package Update Reference, Breaking Changes Catalog, Testing Strategy, Source Control Strategy, and Success Criteria

This is the code block that represents the suggested code change:

````````markdown
## Package Update Reference

### Common Package Updates

Updates affecting multiple projects:

| Package | Current | Target | Projects Affected | Update Reason |
|---------|---------|--------|-------------------|---------------|
| **Microsoft.Extensions.Hosting** | 8.0.0 | 10.0.1 | 1 project (Bootstrapper) | Framework alignment - Version 10.0.1 aligns with .NET 10.0 framework and includes performance improvements and bug fixes. Backward compatible. |
| **System.Runtime.CompilerServices.Unsafe** | 6.0.0 | 6.1.2 | 1 project (ChakramFF) | Compatibility optimization - Version 6.1.2 provides improved compatibility with .NET 10.0 and includes performance optimizations. Used transitively by other packages. |

### Project-Specific Package Updates

**Byakkoder.ChakramFF.Bootstrapper:**
- Microsoft.Extensions.Hosting: 8.0.0 ? 10.0.1

**ChakramFF:**
- System.Runtime.CompilerServices.Unsafe: 6.0.0 ? 6.1.2
- System.Data.DataSetExtensions: 4.5.0 ? **Remove** (functionality now in framework)

### Packages Requiring No Updates

The following packages are already compatible with .NET 10.0:

| Package | Version | Projects | Notes |
|---------|---------|----------|-------|
| coverlet.collector | 6.0.0 | FFmpegWrapperCore.Test | Code coverage collector for tests |
| Microsoft.CSharp | 4.7.0 | ChakramFF | Dynamic language runtime support |
| Microsoft.NET.Test.Sdk | 17.8.0 | FFmpegWrapperCore.Test | Test platform SDK |
| Moq | 4.20.70 | FFmpegWrapperCore.Test | Mocking framework for tests |
| MSTest.TestAdapter | 3.1.1 | FFmpegWrapperCore.Test | MSTest test adapter |
| MSTest.TestFramework | 3.1.1 | FFmpegWrapperCore.Test | MSTest test framework |
| Unity | 5.11.7 | ChakramFF | Dependency injection container |

---

## Breaking Changes Catalog

### Windows Forms Breaking Changes

**Nature of Issues: Binary Incompatible (4,146 occurrences)**

**Context:** Windows Forms types (Button, Panel, Label, TextBox, etc.) are flagged as "binary incompatible" because they moved from `System.Windows.Forms.dll` to different assembly locations in .NET Core 3.0+. However, **all types remain fully available** in .NET 10.0-windows with the same public API surface.

**Most Frequent Types Affected:**

| Type | Occurrences | Impact |
|------|-------------|--------|
| System.Windows.Forms.Button | 503 | Designer-generated button controls |
| System.Windows.Forms.Panel | 358 | Designer-generated panel containers |
| System.Windows.Forms.AnchorStyles | 279 | Control anchoring properties |
| System.Windows.Forms.Label | 154 | Designer-generated label controls |
| System.Windows.Forms.TextBox | 119 | Designer-generated text input controls |
| System.Windows.Forms.Padding | 100 | Control padding properties |
| System.Windows.Forms.Control.Name | 91 | Control name properties |
| System.Windows.Forms.Control.Controls | 90 | Control collection properties |
| System.Windows.Forms.FlatStyle | 90 | Button flat style enumeration |
| System.Windows.Forms.Control.Size | 88 | Control size properties |

**Expected Resolution:**

? **Automatic:** 95%+ of issues resolve automatically upon retargeting. Compiler references correct assemblies without code changes.

?? **Manual (Rare):** If compilation errors occur:
- **Designer regeneration:** Open form in Visual Studio designer, save (regenerates designer file with correct assembly references)
- **Custom control updates:** Update references in custom control libraries if used
- **Event handler signatures:** Verify event handler signatures match expected delegates (rare changes)

**Validation Strategy:**
- Build solution to confirm no compilation errors
- Launch application to verify all forms render correctly
- Test all user interactions (button clicks, text input, etc.)
- Verify no visual regressions (layout, colors, fonts)

### System.Drawing Breaking Changes

**Nature of Issues: Source Incompatible (537 occurrences)**

**Context:** System.Drawing types (Bitmap, Font, GraphicsUnit, etc.) are flagged as "source incompatible" primarily due to namespace changes and potential API adjustments.

**Most Frequent Types Affected:**

| Type | Occurrences | Impact |
|------|-------------|--------|
| System.Drawing.Font | 98 | Font definitions for controls |
| System.Drawing.FontStyle | 92 | Font style enumerations (Regular, Bold, etc.) |
| System.Drawing.GraphicsUnit | 88 | Graphics unit enumerations (Point, Pixel, etc.) |
| System.Drawing.Bitmap | 55 | Image resource properties (icons, images) |
| System.Drawing.ContentAlignment | 33 | Text/content alignment enumerations |

**Expected Resolution:**

**Step 1: Verify Using Directives**

Ensure files have proper using directives:

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;  // If using advanced graphics
using System.Drawing.Imaging;    // If using image formats
using System.Drawing.Text;       // If using font rendering
```

**Step 2: Namespace Adjustments (If Needed)**

If compilation errors occur, fully qualify type names:

```csharp
// Before (if error occurs)
Bitmap icon = Resources.icon;

// After (if using directive doesn't work)
System.Drawing.Bitmap icon = Resources.icon;
```

**Step 3: Constructor/Method Signature Updates (If Needed)**

Some constructors may have signature changes. Check compilation errors for specific guidance.

**Common locations:**
- `ChakramFF\Properties\Resources.Designer.cs` - Resource file properties (auto-generated)
- Form designer files (`*.Designer.cs`) - Control property assignments
- Custom graphics code - Manual painting/rendering methods

**Validation Strategy:**
- Build solution to identify specific source incompatibilities
- Add using directives to resolve namespace issues
- Verify all image resources load correctly at runtime
- Test any custom graphics/painting code visually

### Legacy Configuration System

**Nature of Issues: Potential (4 occurrences)**

**Context:** Usage of app.config-based configuration (`System.Configuration.ConfigurationManager`) which has been replaced by Microsoft.Extensions.Configuration in modern .NET.

**Affected APIs:**
- `ConfigurationManager.AppSettings`
- `ConfigurationManager.ConnectionStrings`
- `app.config` file usage

**Migration Options:**

**Option 1: Bridge Package (Quick Fix)**

Add NuGet package for backward compatibility:

```xml
<PackageReference Include="System.Configuration.ConfigurationManager" Version="10.0.0" />
```

**Pros:** Minimal code changes, works with existing app.config
**Cons:** Maintains legacy dependency, not recommended for long-term

**Option 2: Migrate to Modern Configuration (Recommended)**

Migrate to Microsoft.Extensions.Configuration:

1. **Add package** (if not already present via Bootstrapper):
   ```xml
   <PackageReference Include="Microsoft.Extensions.Configuration" Version="10.0.0" />
   <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.0.0" />
   ```

2. **Convert app.config to appsettings.json:**
   ```json
   {
     "AppSettings": {
       "SettingName": "SettingValue"
     },
     "ConnectionStrings": {
       "DefaultConnection": "ConnectionStringValue"
     }
   }
   ```

3. **Update code:**
   ```csharp
   // Old
   string setting = ConfigurationManager.AppSettings["SettingName"];
   
   // New (inject IConfiguration)
   string setting = configuration["AppSettings:SettingName"];
   ```

**Recommendation for ChakramFF:**

Given the small number of occurrences (4) and All-At-Once strategy:
1. **Immediate:** Use Option 1 (bridge package) to unblock upgrade
2. **Follow-up:** Plan migration to Option 2 in subsequent work

**Validation Strategy:**
- If using bridge package: Verify app.config settings still read correctly
- If migrating: Verify all configuration values accessible from appsettings.json
- Test application startup with configuration-dependent features

### API Changes by Category

**Summary Table:**

| Category | Issue Type | Count | Auto-Resolve | Manual Effort | Priority |
|----------|-----------|-------|--------------|---------------|----------|
| Windows Forms Types | Binary Incompatible | 4,146 | ~95% | ~5% (rare) | Low (auto-resolves) |
| System.Drawing Types | Source Incompatible | 537 | ~80% | ~20% (using directives) | Medium (build errors) |
| Legacy Configuration | Potential | 4 | 0% | 100% (bridge or migrate) | Medium (if used) |

**Overall Impact Assessment:**

- **High-volume, low-impact:** Windows Forms issues are numerous but mostly auto-resolve
- **Medium-volume, medium-impact:** System.Drawing issues require using directives but are straightforward
- **Low-volume, variable-impact:** Configuration issues depend on app.config usage extent

**Build Strategy:**

1. **First build:** Expect System.Drawing namespace errors (source incompatible)
2. **Fix pass:** Add using directives to affected files
3. **Second build:** Expect 0 errors (Windows Forms issues auto-resolved)
4. **Configuration check:** Test application startup to verify configuration access works
5. **Runtime validation:** Launch application to verify Windows Forms rendering and System.Drawing graphics

---

## Testing & Validation Strategy

### Phase Testing Requirements

**Phase 1: Atomic Update**

**Operations:**
- Update all project TargetFramework properties
- Update all package references
- Remove System.Data.DataSetExtensions package
- Restore dependencies (`dotnet restore`)

**Validation:**
- [ ] All project files have correct TargetFramework (net10.0 or net10.0-windows)
- [ ] All package updates applied correctly
- [ ] Restore completes without errors
- [ ] No package version conflicts reported

**Phase 2: Build & Fix**

**Operations:**
- Build entire solution (`dotnet build Chakram.sln`)
- Identify compilation errors
- Apply fixes (using directives, configuration bridge, etc.)
- Rebuild until 0 errors

**Validation:**
- [ ] Solution builds with 0 errors
- [ ] Solution builds with 0 warnings (or only pre-existing warnings)
- [ ] All projects output correct target framework assemblies
- [ ] All project dependencies resolve correctly

**Phase 3: Test Execution**

**Operations:**
- Run FFmpegWrapperCore.Test project
- Address test failures if any
- Rerun until all tests pass

**Validation:**
- [ ] All tests execute successfully
- [ ] All tests pass (0 failures, 0 errors)
- [ ] Test execution time similar to .NET 8.0 baseline
- [ ] No test infrastructure errors (MSTest, Moq work correctly)

**Phase 4: Application Validation**

**Operations:**
- Launch ChakramFF application
- Execute comprehensive manual test scenarios
- Verify UI rendering and functionality
- Test FFmpeg operations end-to-end

**Validation:**
- [ ] Application starts without errors
- [ ] All forms render correctly (no layout issues)
- [ ] All user workflows complete successfully
- [ ] FFmpeg operations execute correctly
- [ ] Performance is acceptable

### Smoke Tests

**Purpose:** Quick validation after each major step to catch issues early.

**After Restore:**
```bash
dotnet restore Chakram.sln --verbosity minimal
# Expected: No errors, all packages restored
```

**After First Build:**
```bash
dotnet build Chakram.sln --no-restore
# Expected: Compilation errors (System.Drawing using directives)
# Note error count and categories
```

**After Fixes Applied:**
```bash
dotnet build Chakram.sln --no-restore --no-incremental
# Expected: 0 errors, 0 warnings
```

**After Test Run:**
```bash
dotnet test Byakkoder.ChakramFF.FFmpegWrapperCore.Test\Byakkoder.ChakramFF.FFmpegWrapperCore.Test.csproj
# Expected: All tests passed
```

**Application Launch:**
```bash
dotnet run --project ChakramFF\ChakramFF.csproj
# Expected: Application window opens, main form renders
```

### Comprehensive Validation

**Code Quality Checks:**

```bash
# Verify target frameworks
dotnet list package --framework

# Check for vulnerable packages
dotnet list package --vulnerable

# Check for deprecated packages
dotnet list package --deprecated

# Analyze output assemblies
dir /s /b bin\Debug\net10.0*\*.dll
```

**Functional Test Scenarios:**

**Scenario 1: Single File Conversion**
1. Launch ChakramFF application
2. Select "Single File" mode
3. Browse and select test video file
4. Configure conversion settings (format, quality, etc.)
5. Click "Convert" button
6. Observe progress tracking
7. Verify output file generated correctly
8. Verify output file playable

**Scenario 2: Batch Conversion**
1. Select "Multiple Files" mode
2. Browse and select multiple test video files
3. Configure batch conversion settings
4. Click "Convert" button
5. Observe progress for each file
6. Verify all output files generated correctly

**Scenario 3: Preview Functionality**
1. Select video file
2. Click "Preview" button
3. Verify preview window opens
4. Verify video preview renders correctly
5. Close preview window

**Scenario 4: Settings Management**
1. Open Settings dialog
2. Modify settings (output path, default format, etc.)
3. Save settings
4. Close and reopen application
5. Verify settings persisted correctly

**Scenario 5: Error Handling**
1. Attempt to convert invalid/corrupted file
2. Verify appropriate error message displayed
3. Verify application remains stable (no crash)

**Performance Test Scenarios:**

**Baseline Comparison:**
1. Record metrics from .NET 8.0 version:
   - Application startup time
   - Form load times
   - Conversion time for standard test file
   - Memory usage during conversion

2. Measure same metrics in .NET 10.0 version

3. Compare results:
   - ? Acceptable: Performance within ±10% of baseline
   - ?? Investigate: Performance degradation >10%
   - ? Bonus: Performance improvement

**Stress Testing:**
1. Convert large video file (>1GB)
2. Batch convert 10+ files
3. Monitor memory usage (should remain stable)
4. Monitor CPU usage (should be similar to baseline)

**Regression Test Checklist:**

UI Components:
- [ ] All forms render correctly
- [ ] All buttons respond to clicks
- [ ] All text inputs accept text
- [ ] All dropdowns display options
- [ ] All icons/images load correctly
- [ ] All dialogs open/close correctly
- [ ] Application can minimize/maximize/restore
- [ ] Application can close without errors

Functionality:
- [ ] File selection dialogs work
- [ ] File conversion completes successfully
- [ ] Preview functionality works
- [ ] Settings persistence works
- [ ] Error messages display correctly
- [ ] Progress tracking updates correctly
- [ ] Output file naming conventions correct
- [ ] FFmpeg operations execute correctly

Integration:
- [ ] Dependency injection resolves services
- [ ] FFmpegWrapperCore integration works
- [ ] Entity data models serialize/deserialize
- [ ] Interface implementations function correctly

---

## Source Control Strategy

### Branching Strategy

**Current State:**
- **Main branch:** `main` (source branch, clean state)
- **Upgrade branch:** `upgrade-to-NET10` (currently active, created for this upgrade)

**Branch Purpose:**
- `upgrade-to-NET10` branch isolates all upgrade changes from main codebase
- Allows for clean rollback if needed (`git reset --hard` or delete branch)
- Enables code review before merging to main
- Preserves main branch stability during upgrade process

**Post-Upgrade:**
- Keep `upgrade-to-NET10` branch until upgrade is validated and merged
- After successful merge to main, `upgrade-to-NET10` branch can be deleted
- Tag main branch after merge: `git tag v1.0.0-net10` (or appropriate version)

### Commit Strategy

**All-At-Once Strategy Commit Approach:**

**Single Atomic Commit (Recommended):**

All upgrade changes committed together as single atomic unit:

```bash
git add .
git commit -m "Upgrade solution to .NET 10.0

- Update all projects from net8.0/net8.0-windows to net10.0/net10.0-windows
- Update Microsoft.Extensions.Hosting to 10.0.1 in Bootstrapper
- Update System.Runtime.CompilerServices.Unsafe to 6.1.2 in ChakramFF
- Remove System.Data.DataSetExtensions from ChakramFF (now in framework)
- Fix System.Drawing using directives in ChakramFF
- Add configuration bridge package (if applicable)
- All projects build successfully
- All tests pass
- Application validated manually

Projects upgraded:
- Byakkoder.ChakramFF.Entities
- Byakkoder.ChakramFF.Interfaces
- Byakkoder.ChakramFF.FFmpegWrapperCore
- Byakkoder.ChakramFF.Bootstrapper
- Byakkoder.ChakramFF.FFmpegWrapperCore.Test
- ChakramFF (WinForms application)

Breaking changes addressed:
- Windows Forms binary incompatible types (auto-resolved)
- System.Drawing source incompatibilities (using directives)
- Legacy configuration system (bridge package added)

Validation completed:
- All projects build with 0 errors, 0 warnings
- All unit tests pass
- Application launches successfully
- Core user workflows tested and functional
- No performance regressions observed"
```

**Rationale for Single Commit:**
- **Atomic operation:** All changes are interdependent (can't have some projects on net10.0 and others on net8.0)
- **Easier rollback:** Single commit to revert if issues discovered
- **Clear history:** One logical change = one commit
- **Bisect-friendly:** If issues found later, bisecting will identify upgrade as single point

**Alternative: Staged Commits (If Needed):**

If upgrade process encounters significant challenges requiring multiple attempts:

**Commit 1: Project Files & Packages**
```bash
git add "**/*.csproj"
git commit -m "Update project files and packages for .NET 10.0"
```

**Commit 2: Code Fixes**
```bash
git add "**/*.cs"
git commit -m "Fix compilation errors for .NET 10.0 compatibility"
```

**Commit 3: Configuration Changes**
```bash
git add "**/appsettings.json" "**/app.config"
git commit -m "Update configuration for .NET 10.0"
```

**Note:** Only use staged commits if upgrade spans multiple sessions or requires significant iteration. Prefer single atomic commit.

### Review and Merge Process

**Pre-Merge Checklist:**

Technical Validation:
- [ ] All projects build successfully (0 errors, 0 warnings)
- [ ] All unit tests pass
- [ ] No package vulnerabilities (`dotnet list package --vulnerable`)
- [ ] No deprecated packages (`dotnet list package --deprecated`)
- [ ] Target frameworks correct on all projects

Functional Validation:
- [ ] Application launches successfully
- [ ] Core user workflows tested and functional
- [ ] No visual regressions in UI
- [ ] No functional behavior changes
- [ ] No performance degradations (within ±10% acceptable)

Code Quality:
- [ ] No unnecessary code changes (only upgrade-related changes)
- [ ] Git commit message is descriptive and complete
- [ ] No temporary/debug code left in codebase
- [ ] No commented-out code added

Documentation:
- [ ] Assessment.md reflects final state
- [ ] Plan.md completed (this document)
- [ ] README updated with .NET 10.0 requirement (if applicable)
- [ ] Any build/run instructions updated

**Merge Process:**

**Option 1: Direct Merge (Small Team / Solo)**
```bash
git checkout main
git merge upgrade-to-NET10 --no-ff
git push origin main
git tag v1.0.0-net10
git push origin v1.0.0-net10
```

**Option 2: Pull Request (Team / Review Required)**
1. Push `upgrade-to-NET10` branch to remote:
   ```bash
   git push origin upgrade-to-NET10
   ```

2. Create Pull Request:
   - Title: "Upgrade solution to .NET 10.0"
   - Description: Link to plan.md, assessment.md, list validation completed
   - Reviewers: Assign appropriate team members

3. Code Review:
   - Review project file changes
   - Review package updates
   - Review code fixes (using directives, configuration, etc.)
   - Validate commit message completeness

4. Merge after approval:
   - Use "Squash and merge" to consolidate (if staged commits used)
   - Use "Merge commit" to preserve single commit (if atomic commit used)

5. Tag release after merge

**Post-Merge Actions:**

- [ ] Delete `upgrade-to-NET10` branch (local and remote)
- [ ] Update CI/CD pipelines to use .NET 10.0 SDK
- [ ] Update deployment documentation
- [ ] Notify team of upgrade completion
- [ ] Monitor application in production for issues

**Rollback Plan (If Needed):**

**Before Merge:**
```bash
# Reset upgrade branch to before upgrade commit
git reset --hard <commit-before-upgrade>

# Or delete branch and start over
git checkout main
git branch -D upgrade-to-NET10
```

**After Merge:**
```bash
# Revert merge commit on main
git checkout main
git revert -m 1 <merge-commit-sha>
git push origin main
```

---

## Success Criteria

### Technical Criteria

**All Projects Migrated:**
- [ ] Byakkoder.ChakramFF.Entities targeting net10.0
- [ ] Byakkoder.ChakramFF.Interfaces targeting net10.0
- [ ] Byakkoder.ChakramFF.FFmpegWrapperCore targeting net10.0
- [ ] Byakkoder.ChakramFF.Bootstrapper targeting net10.0
- [ ] Byakkoder.ChakramFF.FFmpegWrapperCore.Test targeting net10.0
- [ ] ChakramFF targeting net10.0-windows

**All Packages Updated:**
- [ ] Microsoft.Extensions.Hosting updated to 10.0.1
- [ ] System.Runtime.CompilerServices.Unsafe updated to 6.1.2
- [ ] System.Data.DataSetExtensions removed
- [ ] All other packages confirmed compatible

**Build Success:**
- [ ] Entire solution builds with `dotnet build Chakram.sln`
- [ ] 0 compilation errors
- [ ] 0 new warnings (pre-existing warnings acceptable)
- [ ] All projects output to correct target framework directories

**Tests Pass:**
- [ ] FFmpegWrapperCore.Test executes successfully
- [ ] All tests pass (0 failures, 0 skipped unless pre-existing)
- [ ] Test execution time within acceptable range

**No Security Issues:**
- [ ] `dotnet list package --vulnerable` reports 0 vulnerabilities
- [ ] `dotnet list package --deprecated` reports 0 critical deprecations

### Quality Criteria

**Code Quality Maintained:**
- [ ] No unnecessary code changes introduced
- [ ] Existing code structure preserved
- [ ] No temporary workarounds that need future cleanup (or documented if necessary)
- [ ] Code formatting consistent with existing style

**Test Coverage Maintained:**
- [ ] All existing tests still run
- [ ] All existing tests still pass
- [ ] Test coverage percentage unchanged or improved
- [ ] No tests disabled/skipped to make upgrade work

**Documentation Updated:**
- [ ] README reflects .NET 10.0 requirement
- [ ] Build instructions updated if needed
- [ ] Deployment documentation updated if needed
- [ ] Assessment.md and plan.md completed

**No Regressions:**
- [ ] All features that worked in .NET 8.0 still work in .NET 10.0
- [ ] No visual UI regressions
- [ ] No functional behavior changes
- [ ] No performance degradations (within ±10% acceptable)

### Process Criteria

**All-At-Once Strategy Followed:**
- [ ] All projects retargeted simultaneously
- [ ] All package updates applied simultaneously
- [ ] Single coordinated build/fix cycle completed
- [ ] No multi-targeting complexity introduced
- [ ] No intermediate states (all projects on net10.0 together)

**Dependency Order Respected:**
- [ ] Foundation projects (Entities, Interfaces) upgraded first conceptually
- [ ] Dependent projects reference upgraded dependencies correctly
- [ ] No dependency version conflicts
- [ ] Build order determined automatically by MSBuild (no manual intervention needed)

**Validation Completed:**
- [ ] All phases validated per Testing & Validation Strategy
- [ ] Smoke tests executed and passed
- [ ] Comprehensive validation scenarios executed and passed
- [ ] Manual UI testing completed
- [ ] Performance baseline comparison completed

**Source Control Managed:**
- [ ] All changes committed to `upgrade-to-NET10` branch
- [ ] Commit message(s) descriptive and complete
- [ ] Branch ready for code review (if applicable)
- [ ] Pre-merge checklist completed
- [ ] Plan exists for merge and post-merge actions

**Rollback Plan Available:**
- [ ] Understand how to rollback if issues discovered
- [ ] Clean state preserved on main branch
- [ ] Upgrade branch isolated and revertible

### Final Success Definition

**The upgrade is considered successful when:**

1. ? **All 6 projects** target .NET 10.0 (or net10.0-windows)
2. ? **All 2 package updates** applied successfully
3. ? **System.Data.DataSetExtensions** removed without issues
4. ? **Solution builds** with 0 errors and 0 new warnings
5. ? **All unit tests** pass
6. ? **ChakramFF application** launches and runs correctly
7. ? **All core user workflows** functional (file conversion, preview, settings)
8. ? **No security vulnerabilities** in dependencies
9. ? **No performance regressions** (within ±10% acceptable)
10. ? **Changes committed** atomically to upgrade branch
11. ? **Code review completed** (if applicable)
12. ? **Ready to merge** to main branch

**Upgrade is NOT successful if:**

- ? Any project fails to build
- ? Any unit tests fail
- ? Application fails to launch or crashes during normal operation
- ? Any core user workflow broken or degraded
- ? Security vulnerabilities introduced
- ? Significant performance degradation (>10% regression)
- ? Visual UI regressions present

**When all success criteria met:**
- Merge `upgrade-to-NET10` branch to `main`
- Tag release appropriately
- Update deployment pipelines
- Delete upgrade branch
- **Celebrate!** ??

# Unity 6

## 文獻

### AI 檢索

+ [build a Unity WebGL project via a command-line interface (CLI)](https://share.google/aimode/kZrqHEKvvcI7CnXLi)
+ [create a project using the command-line interface](https://share.google/aimode/A4c6Qd6ZZyx0taC30)

### 教學文獻

+ [老菜雞環境認識＆與Unity的初相識-Unity概要&環境建置(安裝Unity Hub)](https://ithelp.ithome.com.tw/m/articles/10289868)
+ [官方教學文件](https://docs.unity3d.com/Manual/index.html)
    - Interface & Essentials
    - User Interface
    - 2D Game creation
    - Graphics
    - Script

## Continuous integration

### [GameCI](https://game.ci/)

+ [unityci/base](https://hub.docker.com/r/unityci/base) 基礎環境不包括任何 Unity 安裝
+ [unityci/hub](https://hub.docker.com/r/unityci/base) 基於 unityci/base 安裝最新版本 Unity hub
+ [unityci/editor](https://hub.docker.com/r/unityci/editor) 基於 unityci/hub 安裝 andoird、ios 開發模組

The unityci/editor Docker images support a wide range of Unity versions, from older LTS releases like 2019.4 and 2022.3 up to the latest Unity 6.x (e.g., 6.0, 6.3 LTS), with new versions added rapidly for CI/CD use via the GameCI project.

+ [Unity hub docker image - AI retrieve](https://share.google/aimode/sWem4iR9AcuEuszv7)

The official and community-maintained game-ci/docker GitHub repository provides Dockerfiles for Unity projects, including a specific Dockerfile for the Unity Hub. This image is primarily used for automation (CI/CD) and running headless Unity commands.

### [Install the Unity Hub in Ubuntu](https://docs.unity3d.com/hub/manual/InstallHub.html)

The Unity Build Pipeline is the automated workflow that converts a Unity project's source code and assets into a production-ready application for a target platform (e.g., iOS, Android, PC). Key components include the BuildPipeline class, the Scriptable Build Pipeline (SBP), and the Addressables system.

+ [Unity CICD - 程式的究極目的就是什麼都不用做](https://ithelp.ithome.com.tw/m/articles/10345401)
+ [Introduction to customizing the build pipeline](https://docs.unity3d.com/6000.3/Documentation/Manual/BuildPlayerPipeline.html)
+ [Using the Unity Hub from the command line](https://docs.unity3d.com/hub/manual/HubCLI.html)

## Unity Version Control (UVC)

+ [Unity version control - AI retrieve](https://share.google/aimode/meneIWvNtaWzn1Tdo)
+ [Unity version control - wiki](https://en.wikipedia.org/wiki/Unity_Version_Control)
+ [Install Unity Version Control on Linux](https://docs.unity.com/en-us/unity-version-control/install-uvcs-on-linux)
+ [Unity Version Control CLI](https://docs.unity.com/en-us/unity-version-control/uvcs-cli/version-control-cli)

Unity Plastic SCM is a version control system (VCS), specifically optimized for game development and working with large files and binaries. It is now officially known as Unity Version Control.

Key features and details:

+ Purpose: It is a source code management (SCM) and VCS tool designed to help programmers, artists, and designers collaborate efficiently on game development projects.
+ Optimization for large files: Unlike general-purpose VCS like Git (which often requires extensions like LFS for large files), Unity Version Control is built to handle the large binary assets (e.g., textures, models, scene files) common in game development performantly.
+ Workflows: It offers both centralized and distributed (DVCS) workflows and provides separate interfaces (Plastic for programmers, Gluon for artists) to accommodate different technical comfort levels and needs within a single project.
+ Integration: It integrates directly with the Unity Editor, as well as other engines like Unreal, and other development tools such as Jira and Jenkins.
+ Deployment options: Teams can host their repositories in the cloud for convenience or deploy on-premises for full control over their data and security.
+ Features: Core features include robust branching and merging capabilities, file locking to prevent conflicts with binary files, and a visual branch explorer.

### Plastic SCM vs Gitlab

| Topic | Plastic SCM | Gitlab |
| :- | :--- | :--- |
| Focus | Version Control (esp. binaries/games) | Full DevOps Lifecycle Platform |
| Workflow | SVN-style (centralized) and Git-style (distributed) | Purely distributed |
| Assets | Shines at large binaries file | Handles code better |
| Features | Focuses on core VCS with strong merging/visualization | Bundles CI/CD |

### [Unity Version Control (previously Plastic SCM) - Migrating from Git](https://docs.unity.com/en-us/unity-version-control/migrating-from-git)

You can integrate a local Plastic SCM (now Unity Version Control) setup with a local GitLab instance by using Plastic SCM's built-in Git compatibility features, specifically GitSync (client-side) or an on-premises GitServer (server-side).

##### Method 1: Using GitSync (Recommended for occasional syncs or local Git workflows)

GitSync allows a Plastic SCM client to push and pull changesets to a remote Git repository, which includes your local GitLab server.
1. Configure GitLab Repository: Ensure you have a project set up in your local GitLab with a remote URL (e.g., your-gitlab.local). You may need a Personal Access Token for authentication if your GitLab requires it.
2. Open Plastic SCM Client: Launch the Plastic SCM GUI.
3. Sync with Git: Right-click on the specific branch you wish to sync within the "Branches" tab in the Branch Explorer.
4. Add Git Repository URL: Select the Sync with Git option. You will be prompted to enter your GitLab repository URL, username, and password/token.
5. Push or Pull Changes: You can now push your Plastic SCM changes to GitLab or pull changes from GitLab into your Plastic SCM repository.

##### Method 2: Using Plastic SCM GitServer (Recommended for continuous integration)

Every on-premises Plastic SCM server can act as a Git server, allowing any standard Git client (including a local GitLab's CI/CD runners or direct Git commands) to push/pull directly to it using the Git protocol.

1. Ensure On-Premises Server: This feature is only available with an on-premises Plastic SCM server, not the Plastic Cloud edition.
2. Enable Git Protocol: The Plastic SCM server must be configured to expose its repositories via the Git protocol (HTTPS or Git protocols are supported).
3. Connect GitLab: You can then configure your GitLab integrations or CI/CD pipelines to interact with the Plastic SCM server using the standard Git commands and the Plastic SCM server's Git-compatible URL. This allows existing Git-based tools to connect directly to Plastic SCM.
-----------

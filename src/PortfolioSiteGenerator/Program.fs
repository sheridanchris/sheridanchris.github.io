open System.IO
open Feliz.ViewEngine

type Project =
    { Name: string
      Description: string
      Technologies: string list
      Href: string }

let projects =
    [ { Name = "F# for you!"
        Description = "A learning resource for developers interested in F#."
        Technologies = ["F#"; "fsdocs"]
        Href = "https://fsharpforyou.github.io" }

      { Name = "ProjectManagementSolution"
        Description = "A real-time project management solution for individuals and teams."
        Technologies = ["C#"; "TypeScript"; "ASP.NET Core"; "React"; "Postgresql"; "Redis"]
        Href = "https://github.com/sheridanchris/ProjectManagementSolution" }

      { Name = "Exodus"
        Description = "A dotnet tool for migrating PostgreSQL databases."
        Technologies = ["F#"]
        Href = "https://github.com/sheridanchris/Exodus" } ]

let projectCard (project: Project) =
    Html.div [
        prop.className "card"
        prop.children [
            Html.div [
                prop.className "card-content"
                prop.children [
                    Html.p [
                        prop.className "title"
                        prop.text project.Name
                    ]
                    Html.p [
                        prop.className "subtitle"
                        prop.text project.Description
                    ]
                    for technology in project.Technologies do
                        Html.span [
                            prop.className "tag is-success"
                            prop.text technology
                            prop.style [
                                style.marginRight 2
                            ]
                        ]
                ]
            ]
            Html.footer [
                prop.className "card-footer"
                prop.children [
                    Html.p [
                        prop.className "card-footer-item"
                        prop.children [
                            Html.span [
                                Html.a [
                                    prop.text "View"
                                    prop.href project.Href
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

let page =
    Html.html [
        Html.head [
            Html.title "Portfolio"
            Html.link [
                prop.href "https://cdn.jsdelivr.net/npm/bulma@0.9.4/css/bulma.min.css"
                prop.rel "stylesheet"
            ]
        ]
        Html.section [
            prop.className "section is-medium"
            prop.children [
                Html.h1 [
                    prop.className "title"
                    prop.text "What I'm Working On!"
                ]
                Html.div [
                    for project in projects do
                        Html.div [
                            prop.className "block"
                            prop.children [
                                projectCard project
                            ]
                        ]
                ]
            ]
        ]
    ]

let writeHtml html = File.WriteAllText("index.html", html)
page |> Render.htmlView |> writeHtml

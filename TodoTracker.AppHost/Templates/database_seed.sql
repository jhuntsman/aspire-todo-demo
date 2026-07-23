-- =========================================================================
-- 1. CREATE TABLES & RELATIONSHIPS
-- =========================================================================

-- Projects Table (Parent workspace)
CREATE TABLE IF NOT EXISTS "Projects"
(
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(150) NOT NULL
);

-- TodoItems Table (Child items linked to a Project)
CREATE TABLE IF NOT EXISTS "TodoItems"
(
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(200) NOT NULL,
    "Description" TEXT,
    "IsCompleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "ProjectId" INT NOT NULL,
    CONSTRAINT "FK_TodoItems_Projects_ProjectId"
    FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("Id") ON DELETE CASCADE
);

-- Tags Table (Categorical tags)
CREATE TABLE IF NOT EXISTS "Tags"
(
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(50) NOT NULL UNIQUE
);

-- TodoItemTags Table (Many-to-Many Join Table)
CREATE TABLE IF NOT EXISTS "TodoItemTags"
(
    "TodoItemsId" INT NOT NULL,
    "TagsId" INT NOT NULL,
    PRIMARY KEY ("TodoItemsId","TagsId"),
    CONSTRAINT "FK_TodoItemTags_TodoItems_TodoItemsId"
    FOREIGN KEY ("TodoItemsId") REFERENCES "TodoItems" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_TodoItemTags_Tags_TagsId" FOREIGN KEY("TagsId") REFERENCES "Tags" ("Id") ON DELETE CASCADE
);

-- =========================================================================
-- 2. INSERT SAMPLE SEED DATA
-- =========================================================================

-- Insert Projects
INSERT INTO "Projects" ("Id", "Name")
VALUES (1, 'Cloud Modernization'),
       (2, 'C64 Homebrew Game'),
       (3, 'Corporate Knowledge Transfer') ON CONFLICT ("Id") DO NOTHING;

-- Reset sequence for Projects
SELECT setval('"Projects_Id_seq"', (SELECT COALESCE(MAX("Id"), 1) FROM "Projects"));

-- Insert Todo Items
INSERT INTO "TodoItems" ("Id", "Title", "Description", "IsCompleted", "ProjectId")
VALUES (1, 'Configure .NET Aspire AppHost', 'Set up project references and orchestrate postgres container', TRUE, 1),
       (2, 'Define Bicep Deployment Scripts', 'Write templates for Azure infrastructure provisioning', FALSE, 1),
       (3, 'Implement Hot Chocolate Fusion Subgraphs', 'Configure federated GraphQL endpoints for backend services',
        FALSE, 1),
       (4, 'Design Splash Screen Asset', 'Finalize title screen artwork for Journey to Thunder Peak', TRUE, 2),
       (5, 'Write 6502 Assembly Movement Loop', 'Optimize player collision detection code using cc65', FALSE, 2),
       (6, 'Build PowerPoint Presentation Deck', 'Create slides detailing technical background and Aspire architecture',
        TRUE, 3),
       (7, 'Prepare Live Coding Demo', 'Test multi-table EF Core queries and GraphQL playground interactions', FALSE,
        3) ON CONFLICT ("Id") DO NOTHING;

-- Reset sequence for TodoItems
SELECT setval('"TodoItems_Id_seq"', (SELECT COALESCE(MAX("Id"), 1) FROM "TodoItems"));

-- Insert Tags
INSERT INTO "Tags" ("Id", "Name")
VALUES (1, 'Backend'),
       (2, 'Frontend'),
       (3, 'Urgent'),
       (4, 'Architecture'),
       (5, 'DevOps') ON CONFLICT ("Id") DO NOTHING;

-- Reset sequence for Tags
SELECT setval('"Tags_Id_seq"', (SELECT COALESCE(MAX("Id"), 1) FROM "Tags"));

-- Insert Many-to-Many Mappings (TodoItemTags)
INSERT INTO "TodoItemTags" ("TodoItemsId", "TagsId")
VALUES (1, 1),
       (1, 4),
       (2, 4),
       (2, 5),
       (3, 1),
       (3, 4),
       (4, 2),
       (5, 1),
       (6, 3),
       (7, 3),
       (7, 4) ON CONFLICT ("TodoItemsId", "TagsId") DO NOTHING;
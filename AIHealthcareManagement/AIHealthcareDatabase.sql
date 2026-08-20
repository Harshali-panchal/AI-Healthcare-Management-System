USE AIHealthcareManagementDB;
GO

INSERT INTO Users
(
    Username,
    Email,
    PasswordHash,
    RoleId,
    IsActive
)
VALUES
(
    'testpatient',
    'patient@test.com',
    'TestPasswordHash',
    1,
    1
);
GO
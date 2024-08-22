Feature: Gestión de Productos

@tag1
Scenario: Agregar un nuevo producto
    Given Llenar los campos del producto
    | ProductName | Category    | Price | StockQuantity |
    | Laptop      | Electrónica | 1500  | 10            |
    When El producto se ingresa en la BDD
    | ProductName | Category    | Price | StockQuantity |
    | Laptop      | Electrónica | 1500  | 10            |
    Then El producto se guarda correctamente en la BDD
    | ProductName | Category    | Price | StockQuantity |
    | Laptop      | Electrónica | 1500  | 10            |

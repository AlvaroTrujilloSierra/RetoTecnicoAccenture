Feature: Realizar compra en Demoblaze

  Scenario Outline: Comprar un producto de una categoría
    Given que el usuario se registra con nombre "<nombre>" y contraseña "<contraseña>"
    When el usuario selecciona la categoría "<categoria>" y el producto "<producto>"
    And añade el producto al carrito
    Then el usuario completa la compra

  Examples:
    | nombre     | contraseña | categoria | producto     |
    | alvarodaniel10111111   | pass123    | Phones    | Nexus 6  |
    | alvarodaniel20111111   | pass123    | Laptops   | MacBook air    |

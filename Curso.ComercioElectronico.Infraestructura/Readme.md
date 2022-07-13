Commandos para agragar la migracion

# Agragar migracion inicial
add-migration Inicial -Context ComercioElectronicoDbContext

# Agregar migracion
add-migration AddProductEntity -Context ComercioElectronicoDbContext

#aplicacr migracion
Update-Database -Context ComercioElectronicoDbContext

#migracion por script
Script-migration -Context ComercioElectronicoDbContext -From Inicial

#genera script
Script-Migration -Context ComercioElectronicoDbContext 0

#migrar un script en especifico
Script-Migration -Context ComercioElectronicoDbContext AddBrandEntity
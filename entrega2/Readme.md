
# Repositorio Git LFS

Descargamos Git-LFS de https://git-lfs.github.com/

Instalamos LFS en el sistema: `git lfs install`

Iniciamos un nuevo repositorio git: `git init`

Para trackear un fichero con LFS usamos: `git lfs track "*.png"`


Para dejar de tracker un fichero usamos: `git los untracked ".jpg"`


Añadimos y comitteamos .gitattributes que contiene la información de tracking LFS

`git -add .gitattributes`

`git commit -m "Añadidos formatos LFS"`


Añadimos distintos ficheros diferentes al repositorio

`git -add wood.png`

`git commit -m "Añadido fichero`


Comprobamos que solo los ficheros marcados para seguimiento están siendo trajeados

`git lfs ls-files`


En el caso de que queramos migrar un proyecto existente a LFS podemos usar

`git lfs migrate`

Más información en
https://github.com/git-lfs/git-lfs/blob/master/docs/man/git-lfs-migrate.1.ronn?utm_source=gitlfs_site&utm_medium=doc_man_migrate_link&utm_campaign=gitlfs

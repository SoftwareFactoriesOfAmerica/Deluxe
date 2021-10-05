===== Common Git commands =====

	VS Code:	https://code.visualstudio.com/Docs/editor/versioncontrol
	git - https://stackoverflow.com/questions/572549/difference-between-git-add-a-and-git-add
	

===== Git add project to git local =====
git update-git-for-windows

	cd "path to your repo"
	git init
	git add . # if you want to commit everything. Otherwise use .gitconfig files
	git commit -m "initial commit" # If you change anything, you can add and commit again...

===== Git add git local to remote =====

	git remote add origin https://jta-bi.visualstudio.com/_git/Amelio-React
	git remote show origin # if everything is ok, you will see your remote
	git push -u origin master # assuming your are on the master branch.

===== git remove and change remote =====

	git remote -v
	git remote set-url origin https://jta-bi.visualstudio.com/_git/Amelio-React
	git remove -v

===== git commands when updating change(s) =====
-- be sure that a gitignore is in place
git add .
git commit -m " <commit message>"
git push origin <branch>

===== git common commands =====
git branch
git branch testing		Creating a New Branch called testing

git branch -D <local branch name>
git list branches

git checkout <branch name>

git checkout -b <branch name>

git commit -m <commit message>
git commit --amend -m <new commit message>

git diff

git help -a

git init

git log

git merge <branch>

git mv <oldfilename> <newfilename>

git pull

git reset --hard

git stash

git status

===== git pull request (PR) =====
git request-pull --help


git checkout -b <branch-name>
git request-pull master ./


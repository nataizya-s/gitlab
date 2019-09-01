import { EduVaultTemplatePage } from './app.po';

describe('EduVault App', function() {
  let page: EduVaultTemplatePage;

  beforeEach(() => {
    page = new EduVaultTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
